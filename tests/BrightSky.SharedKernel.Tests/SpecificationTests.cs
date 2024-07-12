using System.Linq.Expressions;

namespace BrightSky.SharedKernel.Tests;

public class SpecificationTests
{
    private static class TestData
    {
        public static IEnumerable<object[]> ForString50()
        {
            const string stringOf50Chars = "7taEVfUx46Xrnn8UN4AE0p3mSXo9ZqLDznrDLuB0HWmcGrxkXB";
            for (var i = 1; i <= 50; i++)
                yield return new object[] { stringOf50Chars[..i] };
        }        
        
        public static IEnumerable<object[]> ForStringAorB()
        {
            yield return new object[] { "A" };
            yield return new object[] { "B" };
        }
    }
    
    public class StringMustNotBeNullOrWhiteSpaceSpecification : Specification<string?>
    {
        public override Expression<Func<string?, bool>> ToExpression()
            => s => !string.IsNullOrWhiteSpace(s);
    }
    
    public class StringMustBeMinLengthOf1Specification : Specification<string?>
    {
        public override Expression<Func<string?, bool>> ToExpression()
            => s => s != null && s.Length >= 1;
    }
        
    public class StringMustBeMaxLengthOf50Specification : Specification<string?>
    {
        public override Expression<Func<string?, bool>> ToExpression()
            => s => s != null && s.Length <= 50;
    }

    public class StringMustBeUpperCaseASpecification : Specification<string?>
    {
        public override Expression<Func<string?, bool>> ToExpression()
            => s => s != null && s == "A";
    }
    
    public class StringMustBeUpperCaseBSpecification : Specification<string?>
    {
        public override Expression<Func<string?, bool>> ToExpression()
            => s => s != null && s == "B";
    }
    
    [Theory]
    [InlineData((string?)null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijX")]
    public void Specification_For_String50_When_Value_Returns_False(string? value)
    {
        var string50Spec = new StringMustNotBeNullOrWhiteSpaceSpecification()
            .And(new StringMustBeMinLengthOf1Specification())
            .And(new StringMustBeMaxLengthOf50Specification());

        var actual = string50Spec.IsSatisfiedBy(value);
        
        Assert.False(actual);
    }

    [Theory]
    [MemberData(nameof(TestData.ForString50), MemberType = typeof(TestData))]
    public void Specification_For_String50_When_Value_Returns_True(string value)
    {
        var stringAOrBSpec = new StringMustNotBeNullOrWhiteSpaceSpecification()
            .Or(new StringMustBeUpperCaseASpecification())
            .Or(new StringMustBeUpperCaseBSpecification());

        var actual = stringAOrBSpec.IsSatisfiedBy(value);
        
        Assert.True(actual);
    }
    
    [Theory]
    [InlineData((string?)null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("a")]
    [InlineData("AA")]
    [InlineData("A ")]
    [InlineData(" A")]
    [InlineData(" A ")]
    [InlineData("b")]
    [InlineData("BB")]
    [InlineData("B ")]
    [InlineData(" B")]
    [InlineData(" B ")]
    [InlineData("X")]
    public void Specification_For_StringAorB_When_Value_Returns_False(string? value)
    {
        var specification = new StringMustBeUpperCaseASpecification()
            .Or(new StringMustBeUpperCaseBSpecification());

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.False(actual);
    }
    
    [Theory]
    [MemberData(nameof(TestData.ForStringAorB), MemberType = typeof(TestData))]
    public void Specification_For_StringAorB_When_Value_Returns_True(string? value)
    {
        var specification = new StringMustNotBeNullOrWhiteSpaceSpecification()
            .And(new StringMustBeMinLengthOf1Specification())
            .And(new StringMustBeMaxLengthOf50Specification());

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.True(actual);
    }
    
    [Fact]
    public void Specification_For_StringMustNotNeNullOrWhiteSpace_When_Value_IsNull_Returns_False()
    {
        string? value = null;
        var specification = new StringMustNotBeNullOrWhiteSpaceSpecification();

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.False(actual);
    }
        
    [Fact]
    public void Specification_For_StringMustNotNeNullOrWhiteSpace_When_Value_IsEmpty_Returns_False()
    {
        string? value = string.Empty;
        var specification = new StringMustNotBeNullOrWhiteSpaceSpecification();

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.False(actual);
    }
    
    [Fact]
    public void Specification_For_StringMustNotNeNullOrWhiteSpace_When_Value_IsOnlyWhiteSpace_Returns_False()
    {
        string? value = " ";
        var specification = new StringMustNotBeNullOrWhiteSpaceSpecification();

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.False(actual);
    }
    
    [Fact]
    public void Specification_For_StringMustNotNeNullOrWhiteSpace_When_Value_IsSomeString_Returns_True()
    {
        string? value = "some value";
        var specification = new StringMustNotBeNullOrWhiteSpaceSpecification();

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.True(actual);
    }
    
    [Fact]
    public void Specification_For_StringMustBeMinLengthOf1_When_Value_IsNull_Returns_False()
    {
        string? value = null;
        var specification = new StringMustBeMinLengthOf1Specification();

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.False(actual);
    }
        
    [Fact]
    public void Specification_For_StringMustBeMinLengthOf1_When_Value_IsEmpty_Returns_False()
    {
        string? value = string.Empty;
        var specification = new StringMustBeMinLengthOf1Specification();

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.False(actual);
    }
    
    [Fact]
    public void Specification_For_StringMustBeMinLengthOf1_When_Value_IsSomeString_Returns_True()
    {
        string? value = "a";
        var specification = new StringMustBeMinLengthOf1Specification();

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.True(actual);
    }
    
    [Fact]
    public void Specification_For_StringMustBeMaxLengthOf50_When_Value_IsNull_Returns_False()
    {
        string? value = null;
        var specification = new StringMustBeMaxLengthOf50Specification();

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.False(actual);
    }
        
    [Fact]
    public void Specification_For_StringMustBeMaxLengthOf50_When_Value_IsEmpty_Returns_True()
    {
        string? value = string.Empty;
        var specification = new StringMustBeMaxLengthOf50Specification();

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.True(actual);
    }
    
    [Fact]
    public void Specification_For_StringMustBeMaxLengthOf50_When_Value_LengthIsLessThan50_Returns_True()
    {
        string? value = "a";
        var specification = new StringMustBeMaxLengthOf50Specification();

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.True(actual);
    }
    
    [Fact]
    public void Specification_For_StringMustBeMaxLengthOf50_When_Value_LengthIsMoreThan50_Returns_False()
    {
        string? value = "abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijX";
        var specification = new StringMustBeMaxLengthOf50Specification();

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.False(actual);
        Assert.Equal(51, value.Length);
    }
    
    [Fact]
    public void Specification_For_StringMustBeUpperCaseA_When_Value_IsEmpty_Returns_False()
    {
        string value = string.Empty;
        var specification = new StringMustBeUpperCaseASpecification();

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.False(actual);
    }    
    
    [Fact]
    public void Specification_For_StringMustBeUpperCaseA_When_Value_IsNotUpperCaseA_Returns_False()
    {
        string value = "a";
        var specification = new StringMustBeUpperCaseASpecification();

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.False(actual);
    }
    
    [Fact]
    public void Specification_For_StringMustBeUpperCaseA_When_Value_IsUpperCaseA_Returns_True()
    {
        string value = "A";
        var specification = new StringMustBeUpperCaseASpecification();

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.True(actual);
    }
    
    [Fact]
    public void Specification_For_StringMustBeUpperCaseB_When_Value_IsEmpty_Returns_False()
    {
        string value = string.Empty;
        var specification = new StringMustBeUpperCaseBSpecification();

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.False(actual);
    }    
    
    [Fact]
    public void Specification_For_StringMustBeUpperCaseB_When_Value_IsNotUpperCaseB_Returns_False()
    {
        string value = "b";
        var specification = new StringMustBeUpperCaseBSpecification();

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.False(actual);
    }
    
    [Fact]
    public void Specification_For_StringMustBeUpperCaseB_When_Value_IsUpperCaseB_Returns_True()
    {
        string value = "B";
        var specification = new StringMustBeUpperCaseBSpecification();

        var actual = specification.IsSatisfiedBy(value);
        
        Assert.True(actual);
    }
}