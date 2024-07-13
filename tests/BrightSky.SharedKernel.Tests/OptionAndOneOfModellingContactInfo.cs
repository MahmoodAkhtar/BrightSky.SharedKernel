using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace BrightSky.SharedKernel.Tests;

public class OptionAndOneOfModellingContactInfo
{
    public readonly record struct String50
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

    public readonly record struct String100
    {
        private static readonly Specification<string?> String100Spec = new String100Specification();
        
        private readonly string _value;

        private String100(string value) =>
            _value = Precondition.Requires(value).Meets(String100Spec!).ThenAssignOrThrow<string, ArgumentException>();

        public static String100 Create(string value) => new(value);

        public static implicit operator string(String100 value) => value._value;
        public static explicit operator String100(string value) => Create(value);

        private class String100Specification : Specification<string?>
        {
            public override Expression<Func<string?, bool>> ToExpression()
                => s => !string.IsNullOrWhiteSpace(s) && s.Length >= 1 && s.Length <= 100;
        }
    }    
    
    public readonly record struct Fullname
    {
        public String50 Firstname { get; init; }
        public String50 Lastname { get; init; }
        
        private Fullname(String50 firstname, String50 lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public static Fullname Create(String50 firstname, String50 lastname) => new(firstname, lastname);
        
        public static implicit operator string(Fullname value) => $"{value.Firstname} {value.Lastname}";
    }

    public readonly record struct EmailAddress
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

    public readonly record struct UkPostCode
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

    public record UkPostalAddress
    {
        public String100 HouseNumberAndStreet { get; init; }
        public Option<String100> Locality { get; init; }
        public String100 TownOrCity { get; init; }
        public UkPostCode PostCode { get; init; }

        private UkPostalAddress(
            String100 houseNumberAndStreet, 
            Option<String100> locality, 
            String100 townOrCity, 
            UkPostCode postCode)
        {
            HouseNumberAndStreet = houseNumberAndStreet;
            Locality = locality;
            TownOrCity = townOrCity;
            PostCode = postCode;
        }

        public static UkPostalAddress Create(String100 houseNumberAndStreet, String100 townOrCity, UkPostCode postCode)
            => new(houseNumberAndStreet, Option<String100>.None, townOrCity, postCode);

        public static UkPostalAddress Create(String100 houseNumberAndStreet, String100 locality, String100 townOrCity, UkPostCode postCode)
            => new(houseNumberAndStreet, locality, townOrCity, postCode);
    }

    public readonly record struct UkLandlineNumber
    {
        private static readonly Specification<string?> UkLandlineNumberSpec = new UkLandlineNumberSpecification();
        
        private readonly string _value;

        private UkLandlineNumber(string value) =>
            _value = Precondition.Requires(value).Meets(UkLandlineNumberSpec!).ThenAssignOrThrow<string, ArgumentException>();

        public static UkLandlineNumber Create(string value) => new(value);

        public static implicit operator string(UkLandlineNumber value) => value._value;
        public static explicit operator UkLandlineNumber(string value) => Create(value);
        
        private class UkLandlineNumberSpecification : Specification<string?>
        {
            // See: https://en.wikipedia.org/wiki/Telephone_numbers_in_the_United_Kingdom#Mobile_telephones
            private const string Pattern = @"^[0]\d{9,10}$";

            public override Expression<Func<string?, bool>> ToExpression()
                => s => !string.IsNullOrWhiteSpace(s) && Regex.IsMatch(s, Pattern);
        }
    }

    public readonly record struct  UkMobileNumber
    {
        private static readonly UkMobileNumberSpecification UkMobileNumberSpec = new();
        
        private readonly string _value;

        private UkMobileNumber(string value) =>
            _value = Precondition.Requires(value).Meets(UkMobileNumberSpec!).ThenAssignOrThrow<string, ArgumentException>();

        public static UkMobileNumber Create(string value) => new(value);

        public static implicit operator string(UkMobileNumber value) => value._value;
        public static explicit operator UkMobileNumber(string value) => Create(value);
        
        private class UkMobileNumberSpecification : Specification<string?>
        {
            // See: https://en.wikipedia.org/wiki/Telephone_numbers_in_the_United_Kingdom#Mobile_telephones
            private const string Pattern = @"^07\d{9}$";

            public override Expression<Func<string?, bool>> ToExpression()
                => s => !string.IsNullOrWhiteSpace(s) && Regex.IsMatch(s, Pattern);
        }
    }

    public readonly record struct  InternationalNumber
    {
        private static readonly InternationalNumberSpecification InternationalNumberSpec = new();
        
        private readonly string _value;

        private InternationalNumber(string value) =>
            _value = Precondition.Requires(value).Meets(InternationalNumberSpec!).ThenAssignOrThrow<string, ArgumentException>();

        public static InternationalNumber Create(string value) => new(value);

        public static implicit operator string(InternationalNumber value) => value._value;
        public static explicit operator InternationalNumber(string value) => Create(value);
        
        private class InternationalNumberSpecification : Specification<string?>
        {
            // See: https://en.wikipedia.org/wiki/E.164
            private const string Pattern = @"^\d{11,15}$";

            public override Expression<Func<string?, bool>> ToExpression()
                => s => !string.IsNullOrWhiteSpace(s) && Regex.IsMatch(s, Pattern);
        }        
    }
    
    public record PhoneNumber : OneOf<UkMobileNumber, UkLandlineNumber, InternationalNumber>
    {
        public new static PhoneNumber Case(UkMobileNumber value) => new(value);
        public new static PhoneNumber Case(UkLandlineNumber value) => new(value);
        public new static PhoneNumber Case(InternationalNumber value) => new(value);
        
        public static implicit operator PhoneNumber(UkMobileNumber value) => new(value);
        public static implicit operator PhoneNumber(UkLandlineNumber value) => new(value);
        public static implicit operator PhoneNumber(InternationalNumber value) => new(value);
        
        public static implicit operator UkMobileNumber(PhoneNumber value) => value.Get<UkMobileNumber>();
        public static implicit operator UkLandlineNumber(PhoneNumber value) => value.Get<UkLandlineNumber>();
        public static implicit operator InternationalNumber(PhoneNumber value) => value.Get<InternationalNumber>();
        
        protected PhoneNumber(UkMobileNumber value) : base(value)
        {
        }

        protected PhoneNumber(UkLandlineNumber value) : base(value)
        {
        }
        
        protected PhoneNumber(InternationalNumber value) : base(value)
        {
        }
    }

    public record ContactInfo
    {
        private static readonly UkPostalAddressNotNullSpecification UkPostalAddressNotNullSpec = new();
        private static readonly PhoneNumberNotNullSpecification PhoneNumberNotNullSpec = new();
        
        public EmailAddress Email { get; init; }
        public UkPostalAddress Address { get; init; }
        public PhoneNumber PhoneNumber { get; init; }

        private ContactInfo(EmailAddress email, UkPostalAddress address, PhoneNumber phoneNumber)
        {
            Email = email;
            Address = Precondition.Requires(address).Meets(UkPostalAddressNotNullSpec).ThenAssignOrThrow<UkPostalAddress, ArgumentNullException>();
            PhoneNumber = Precondition.Requires(phoneNumber).Meets(PhoneNumberNotNullSpec).ThenAssignOrThrow<PhoneNumber, ArgumentNullException>();
        }

        public static ContactInfo Create(EmailAddress email, UkPostalAddress address, PhoneNumber phoneNumber)
            => new(email, address, phoneNumber);

        private class UkPostalAddressNotNullSpecification : Specification<UkPostalAddress>
        {
            public override Expression<Func<UkPostalAddress, bool>> ToExpression()
                => x => x != null;
        }

        private class PhoneNumberNotNullSpecification : Specification<PhoneNumber>
        {
            public override Expression<Func<PhoneNumber, bool>> ToExpression()
                => x => x != null;
        }
    }

    public record Contact
    {
        private static readonly ContactInfoNotNullSpecification ContactInfoNotNullSpec = new();
        
        public Fullname Name { get; init; }
        public ContactInfo PrimaryContact { get; init; }
        public Option<ContactInfo> SecondaryContact { get; init; }

        private Contact(Fullname name, ContactInfo primaryContact, Option<ContactInfo> secondaryContact)
        {
            Name = name;
            PrimaryContact = Precondition.Requires(primaryContact).Meets(ContactInfoNotNullSpec).ThenAssignOrThrow<ContactInfo, ArgumentNullException>();
            SecondaryContact = secondaryContact;
        }

        public static Contact Create(Fullname name, ContactInfo primaryContact)
            => new(name, primaryContact, Option<ContactInfo>.None);
        
        public static Contact Create(Fullname name, ContactInfo primaryContact, ContactInfo secondaryContact)
            => new(name, primaryContact, secondaryContact);

        private class ContactInfoNotNullSpecification : Specification<ContactInfo>
        {
            public override Expression<Func<ContactInfo, bool>> ToExpression()
                => x => x != null;
        }
    }

    [Fact]
    public void ContactCreate_Without_SecondaryContact()
    {
        var contact =
            Contact.Create(
                Fullname.Create(
                    String50.Create("Firstname"), 
                    String50.Create("Lastname")
                ),
                ContactInfo.Create(
                    EmailAddress.Create("someone@example.com"),
                    UkPostalAddress.Create(
                        String100.Create("123 Play Street"), 
                        String100.Create("Fun Area"), 
                        String100.Create("Toy Town"), 
                        UkPostCode.Create("TT1 2AB")
                    ),
                    PhoneNumber.Case(UkMobileNumber.Create("07890123456"))
                )
            );

        Assert.IsType<Contact>(contact);
        Assert.Equal(Option<ContactInfo>.None, contact.SecondaryContact);
    }
    
    [Fact]
    public void ContactCreate_With_SecondaryContact()
    {
        var contact =
            Contact.Create(
                Fullname.Create(
                    String50.Create("Firstname"), 
                    String50.Create("Lastname")
                ),
                ContactInfo.Create(
                    EmailAddress.Create("someone@example.com"),
                    UkPostalAddress.Create(
                        String100.Create("123 Play Street"), 
                        String100.Create("Fun Area"), 
                        String100.Create("Toy Town"), 
                        UkPostCode.Create("TT1 2AB")
                    ),
                    PhoneNumber.Case(UkMobileNumber.Create("07890123456"))
                ),
                ContactInfo.Create(
                    EmailAddress.Create("someoneelse@example.com"),
                    UkPostalAddress.Create(
                        String100.Create("456 Play Street"), 
                        String100.Create("Fun Area"), 
                        String100.Create("Toy Town"), 
                        UkPostCode.Create("TT2 3CD")
                    ),
                    PhoneNumber.Case(UkMobileNumber.Create("07896543210"))
                )
            );

        Assert.IsType<Contact>(contact);
    }
    
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