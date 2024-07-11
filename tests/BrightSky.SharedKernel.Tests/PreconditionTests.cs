using System.Linq.Expressions;

namespace BrightSky.SharedKernel.Tests;

public class PreconditionTests
{
    public class StringMustNotBeNullOrWhiteSpaceSpecification : Specification<string?>
    {
        public override Expression<Func<string?, bool>> ToExpression()
            => s => !string.IsNullOrWhiteSpace(s);
    }
    
    [Fact]
    public void PreconditionRequires_Value_When_String_Returns_ResultIsSuccess()
    {
        string? value = null;
        var expected = Result<string?, Error>.Success(value);
        
        var actual = Precondition.Requires(value);
        
        Assert.True(actual.IsSuccess);
        Assert.Equal(expected, actual);
    }
 
    [Fact]
    public void PreconditionMeets_Specification_When_String_Returns_ResultIsSuccess()
    {
        var specification = new StringMustNotBeNullOrWhiteSpaceSpecification();
        string? value = (string?)"some value";
        var expected = Result<string?, Option<Error>>.Success(value);
        
        var actual = Precondition.Requires(value).Meets(specification);
        
        Assert.True(actual.IsSuccess);
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData((string?)null)]
    [InlineData("")]
    [InlineData(" ")]
    public void PreconditionMeets_Specification_When_String_Returns_ResultIsFailure(string? value)
    {
        var specification = new StringMustNotBeNullOrWhiteSpaceSpecification();
        var expected = Result<string?, Option<Error>>.Failure(Error.Failure(
            $"Precondition.{specification.GetType().Name}",
            $"Specification {specification.GetType().Name} was not met"));
        
        var actual = Precondition.Requires(value).Meets(specification);
        
        Assert.True(actual.IsFailure);
        Assert.Equal(expected, actual);
    }
}