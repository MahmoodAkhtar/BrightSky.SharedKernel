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
    
    [Fact]
    public void PreconditionMeets_Specification_When_ResultIsFailure_Returns_ResultIsFailure()
    {
        var specification = new StringMustNotBeNullOrWhiteSpaceSpecification();
        var error = Error.Failure("MyCode", "Some description");
        var expected = Result<string?, Option<Error>>.Failure(error);
        
        var actual = Result<string?, Error>.Failure(error).Meets(specification);
        
        Assert.True(actual.IsFailure);
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void PreconditionThenAssignOrThrow_When_ResultIsFailure_Throw_Exception()
    {
        var error = Error.Failure("MyCode", "Some description");
        var expected = $"{error.Type.Name} {error.Code} {error.Description}";
        string? actual = default;
        
        try
        {
            actual = Result<string?, Option<Error>>.Failure(error).ThenAssignOrThrow<string?, Exception>();
        }
        catch (Exception e)
        {
            Assert.Equal(expected , e.Message); 
        }
        
        Assert.Equal(default, actual);
    }
        
    [Fact]
    public void PreconditionThenAssignOrThrow_When_ResultIsFailure_Throw_ArgumentException()
    {
        var error = Error.Failure("MyCode", "Some description");
        var expected = $"{error.Type.Name} {error.Code} {error.Description}";
        string? actual = default;
        
        try
        {
            actual = Result<string?, Option<Error>>.Failure(error).ThenAssignOrThrow<string?, ArgumentException>();
        }
        catch (ArgumentException e)
        {
            Assert.Equal(expected , e.Message); 
        }
        
        Assert.Equal(default, actual);
    }
    
    [Fact]
    public void PreconditionThenAssignOrThrow_When_ResultIsSuccess_Return_EqualsExpected()
    {
        string? expected = "some value";
        
        var actual = Result<string?, Option<Error>>.Success(expected).ThenAssignOrThrow<string?, Exception>();
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void PreconditionRequires_Value_Meets_StringMustNotBeNullOrWhiteSpaceSpecification_ThenAssign_Value_AsExpected()
    {
        var specification = new StringMustNotBeNullOrWhiteSpaceSpecification();
        string? expected = (string?)"some value";
        
        var actual = Precondition.Requires(expected).Meets(specification).ThenAssignOrThrow<string?, Exception>();
        
        Assert.Equal(expected, actual);
    }
    
        
    [Theory]
    [InlineData((string?)null)]
    [InlineData("")]
    [InlineData(" ")]
    public void PreconditionRequires_Value_DoesntMeet_StringMustNotBeNullOrWhiteSpaceSpecification_ThenThrows_Exception(string? value)
    {
        var specification = new StringMustNotBeNullOrWhiteSpaceSpecification();
        var error = Error.Failure(
            $"Precondition.{specification.GetType().Name}",
            $"Specification {specification.GetType().Name} was not met");
        var expected = $"{error.Type.Name} {error.Code} {error.Description}";
        string? actual = default;
        
        try
        {
            actual = Precondition.Requires(value).Meets(specification).ThenAssignOrThrow<string?, Exception>();
        }
        catch (Exception e)
        {
            Assert.Equal(expected , e.Message);
        }
        
        Assert.Equal(default, actual);
    }
}