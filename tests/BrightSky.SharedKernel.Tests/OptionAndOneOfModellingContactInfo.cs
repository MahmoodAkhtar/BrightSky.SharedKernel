using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace BrightSky.SharedKernel.Tests;

public class OptionAndOneOfModellingContactInfo
{
    public record String50
    {
        private static readonly Specification<string?> String50Spec = new String50Specification();
        
        private readonly string _value;

        private String50(string value) =>
            _value = Precondition.Requires(value).Meets(String50Spec!).ThenAssignOrThrow<string, ArgumentException>();

        public static String50 Create(string value) => new(value);

        public static implicit operator string(String50 value) => value._value;
        public static explicit operator String50(string value) => Create(value);

        private class String50Specification : Specification<string?>
        {
            public override Expression<Func<string?, bool>> ToExpression()
                => s => !string.IsNullOrWhiteSpace(s) && s.Length >= 1 && s.Length <= 50;
        }
    }

    public record Fullname
    {
        private static readonly Specification<String50> NotNullSpec = new NotNullSpecification();

        public String50 Firstname { get; init; }
        public String50 Lastname { get; init; }
        
        private Fullname(String50 firstname, String50 lastname)
        {
            Firstname = Precondition.Requires(firstname).Meets(NotNullSpec)
                .ThenAssignOrThrow<String50, ArgumentNullException>();
            
            Lastname = Precondition.Requires(lastname).Meets(NotNullSpec)
                .ThenAssignOrThrow<String50, ArgumentNullException>();
        }

        public static Fullname Create(String50 firstname, String50 lastname) => new(firstname, lastname);
        
        public static implicit operator string(Fullname value) => $"{value.Firstname} {value.Lastname}";
        
        private class NotNullSpecification : Specification<String50>
        {
            public override Expression<Func<String50, bool>> ToExpression()
                => s50 => s50 != null;
        }
    }

    public record EmailAddress
    {
        private static readonly Specification<string?> EmailAddressSpec = new EmailAddressSpecification();
        
        private readonly string _value;

        private EmailAddress(string value) =>
            _value = Precondition.Requires(value).Meets(EmailAddressSpec!).ThenAssignOrThrow<string, ArgumentException>();

        public static EmailAddress Create(string value) => new(value);

        public static implicit operator string(EmailAddress value) => value._value;
        public static explicit operator EmailAddress(string value) => Create(value);

        private class EmailAddressSpecification : Specification<string?>
        {
            public override Expression<Func<string?, bool>> ToExpression()
                => s => Predicate(s);

            private static bool Predicate(string? value)
            {
                if (string.IsNullOrWhiteSpace(value) && value!.Length <= 255) return false;
                var index = value.IndexOf('@');
                return index > 0 && index != value.Length - 1 && index == value.LastIndexOf('@');
            }
        }
    }

    public record UkPostCode
    {
        private static readonly Specification<string?> UkPostCodeSpec = new UkPostCodeSpecification();
        
        private readonly string _value;

        private UkPostCode(string value) =>
            _value = Precondition.Requires(value).Meets(UkPostCodeSpec!).ThenAssignOrThrow<string, ArgumentException>();

        public static UkPostCode Create(string value) => new(value);

        public static implicit operator string(UkPostCode value) => value._value;
        public static explicit operator UkPostCode(string value) => Create(value);

        private class UkPostCodeSpecification : Specification<string?>
        {
            private const string Pattern = "^(([A-Z]{1,2}[0-9][A-Z0-9]?|ASCN|STHL|TDCU|BBND|[BFS]IQQ|PCRN|TKCA) ?[0-9][A-Z]{2}|BFPO ?[0-9]{1,4}|(KY[0-9]|MSR|VG|AI)[ -]?[0-9]{4}|[A-Z]{2} ?[0-9]{2}|GE ?CX|GIR ?0A{2}|SAN ?TA1)$";

            public override Expression<Func<string?, bool>> ToExpression()
                => s => !string.IsNullOrWhiteSpace(s) && Regex.IsMatch(s, Pattern);
        }
    }
    
    public record UkPostalAddress(
        string HouseNumberAndStreet, 
        Option<string> Locality,            // Locality is optional 
        string TownOrCity, 
        UkPostCode PostCode);
    
    public record LandlineNumber(string Number);
    public record MobileNumber(string Number);
    
    // PhoneNumber can be a mobile or a landline number
    public record PhoneNumber : OneOf<MobileNumber, LandlineNumber>
    {
        public new static PhoneNumber Case(MobileNumber value) => new(value);
        public new static PhoneNumber Case(LandlineNumber value) => new(value);
        
        public static implicit operator PhoneNumber(MobileNumber value) => new(value);
        public static implicit operator PhoneNumber(LandlineNumber value) => new(value);
        
        public static implicit operator MobileNumber(PhoneNumber value) => value.Get<MobileNumber>();
        public static implicit operator LandlineNumber(PhoneNumber value) => value.Get<LandlineNumber>();
        
        protected PhoneNumber(MobileNumber value) : base(value)
        {
        }

        protected PhoneNumber(LandlineNumber value) : base(value)
        {
        }
    }
    
    public record ContactInfo(
        EmailAddress Email, 
        UkPostalAddress Address, 
        PhoneNumber PhoneNumber);
    
    // Requirement: A contact must have at least one way of being contacted
    public record Contact(
        Fullname Name, 
        ContactInfo PrimaryContact,             // This is the primary contact info and is required
        Option<ContactInfo> SecondaryContact);  // This is the secondary contact info and is optional


    private static class TestData
    {
        public static IEnumerable<object[]> ForString50AsExpected()
        {
            const string stringOf50Chars = "7taEVfUx46Xrnn8UN4AE0p3mSXo9ZqLDznrDLuB0HWmcGrxkXB";
            for (var i = 1; i <= 50; i++)
                yield return new object[] { stringOf50Chars[..i] };
        }
        
        public static IEnumerable<object[]> ForString50IsntAsExpected()
        {
            var objects = new object[] { (string?)null, "", " ", "7taEVfUx46Xrnn8UN4AE0p3mSXo9ZqLDznrDLuB0HWmcGrxkXBX" };   
            foreach(var obj in objects)
                yield return new object[] { obj };
        }

        public static IEnumerable<object[]> ForFullnameAsExpected()
        {
            var firstnames = ForString50AsExpected().SelectMany(x => x).OrderBy(x=> Random.Shared.Next()).ToList();
            var lastnames = ForString50AsExpected().SelectMany(x => x).OrderBy(x=> Random.Shared.Next()).ToList();

            for (var i = 0; i < 50; i++)
                yield return new object[] { firstnames[i], lastnames[i] };
        }
    }
    
    [Theory]
    [MemberData(nameof(TestData.ForString50AsExpected), MemberType = typeof(TestData))]
    public void String50Create_When_Value_AsExpected(string expected)
    {
        var actual = String50.Create(expected);
        
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(TestData.ForString50AsExpected), MemberType = typeof(TestData))]
    public void String50_ExplicitOperator_When_Value_AsExpected(string expected)
    {
        var actual = (String50)expected;
        
        Assert.Equal(expected, actual);
    }
        
    [Theory]
    [MemberData(nameof(TestData.ForString50AsExpected), MemberType = typeof(TestData))]
    public void String50_ImplicitOperator_When_Value_AsExpected(string expected)
    {
        string actual = String50.Create(expected);
        
        Assert.Equal(expected, actual);
    }
        
    [Theory]
    [MemberData(nameof(TestData.ForString50IsntAsExpected), MemberType = typeof(TestData))]
    public void String50Create_When_Value_IsntAsExpected(string? value)
    {
        Assert.Throws<ArgumentException>(() => String50.Create(value));
    }
    
    [Theory]
    [MemberData(nameof(TestData.ForFullnameAsExpected), MemberType = typeof(TestData))]
    public void FullnameCreate_When_Firstname_And_Lastname_AsExpected(String50 firstname, String50 lastname)
    {
        var actual = Fullname.Create(firstname, lastname);
        
        Assert.IsType<Fullname>(actual);
        Assert.Equal(firstname, actual.Firstname);
        Assert.Equal(lastname, actual.Lastname);
    }
    
    [Theory]
    [MemberData(nameof(TestData.ForFullnameAsExpected), MemberType = typeof(TestData))]
    public void FullnameCreate_ImplicitOperator_AsExpected(String50 firstname, String50 lastname)
    {
        var actual = Fullname.Create(firstname, lastname);
        
        Assert.Equal($"{firstname} {lastname}", actual);
    }
}