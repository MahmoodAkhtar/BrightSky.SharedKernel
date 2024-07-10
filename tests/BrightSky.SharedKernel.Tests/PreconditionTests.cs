namespace BrightSky.SharedKernel.Tests;

public class PreconditionTests
{
    [Fact]
    public void 
    PreconditionRequires_Value_BeTrueFor_Predicate_OrErrorWithError_PredicateIsFalse_Assert_Error_EqualsExpected()
    {
        string? value = null;

        var expected = Error.Failure("MyCode", $"{nameof(value)} {value} is not null");
        var option = Precondition.Requires(value).BeTrueFor(x => x is not null).OrError(expected);
        
        Assert.True(option.IsSome);
        Assert.Equal(expected, option.Value);
    }
    
    [Fact]
    public void 
    PreconditionRequires_Value_BeTrueFor_Predicate_OrErrorWithError_PredicateIsTrue_Assert_NoError()
    {
        string? value = "some value";

        var error = Error.Failure("MyCode", $"{nameof(value)} {value} is not null");
        var option = Precondition.Requires(value).BeTrueFor(x => x is not null).OrError(error);
        
        Assert.True(option.IsNone);
        Assert.Equal(Option<Error>.None, option);
    }
    
    [Fact]
    public void 
    PreconditionRequires_Value_BeFalseFor_Predicate_OrErrorWithError_PredicateIsTrue_Assert_Error_EqualsExpected()
    {
        string? value = null;

        var expected = Error.Failure("MyCode", $"{nameof(value)} {value} is null");
        var option = Precondition.Requires(value).BeFalseFor(x => x is null).OrError(expected);
        
        Assert.True(option.IsSome);
        Assert.Equal(expected, option.Value);
    }
    
    [Fact]
    public void 
    PreconditionRequires_Value_BeFalseFor_Predicate_OrErrorWithError_PredicateIsFalse_Assert_Error_EqualsExpected()
    {
        string? value = "some value";

        var error = Error.Failure("MyCode", $"{nameof(value)} {value} is null");
        var option = Precondition.Requires(value).BeFalseFor(x => x is null).OrError(error);
        
        Assert.True(option.IsNone);
        Assert.Equal(Option<Error>.None, option);
    }
    
    [Fact]
    public void 
    PreconditionRequires_Value_BeTrueFor_Predicate_OrError_PredicateIsFalse_Assert_Error_EqualsExpected()
    {
        string? value = null;

        var expected = Error.Failure("Precondition.BeTrueFor", "Func<TValue, bool> predicate was false");
        var option = Precondition.Requires(value).BeTrueFor(x => x is not null).OrError();
        
        Assert.True(option.IsSome);
        Assert.Equal(expected, option.Value);
    }
    
    [Fact]
    public void 
    PreconditionRequires_Value_BeTrueFor_Predicate_OrError_PredicateIsTrue_Assert_NoError()
    {
        string? value = "some value";

        var option = Precondition.Requires(value).BeTrueFor(x => x is not null).OrError();
        
        Assert.True(option.IsNone);
        Assert.Equal(Option<Error>.None, option);
    }
    
    [Fact]
    public void 
    PreconditionRequires_Value_BeFalseFor_Predicate_OrError_PredicateIsTrue_Assert_Error_EqualsExpected()
    {
        string? value = null;

        var expected = Error.Failure("Precondition.BeFalseFor", "Func<TValue, bool> predicate was true");
        var option = Precondition.Requires(value).BeFalseFor(x => x is null).OrError();
        
        Assert.True(option.IsSome);
        Assert.Equal(expected, option.Value);
    }
    
    [Fact]
    public void 
    PreconditionRequires_Value_BeFalseFor_Predicate_OrError_PredicateIsFalse_Assert_Error_EqualsExpected()
    {
        string? value = "some value";

        var option = Precondition.Requires(value).BeFalseFor(x => x is null).OrError();
        
        Assert.True(option.IsNone);
        Assert.Equal(Option<Error>.None, option);
    }
}