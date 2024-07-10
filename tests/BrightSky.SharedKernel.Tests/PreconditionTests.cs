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

    [Fact]
    public void 
    PreconditionsAddRange_NullOptions_Returns_Empty_Errors()
    {
        Option<Error>[] options = null;

        var actual = Preconditions.AddRange(options);
        
        Assert.Empty(actual);
    }
    
    [Fact]
    public void 
    PreconditionsAddRange_EmptyOptions_Returns_Empty_Errors()
    {
        var options = Array.Empty<Option<Error>>();

        var actual = Preconditions.AddRange(options);
        
        Assert.Empty(actual);
    }

    [Fact]
    public void 
    PreconditionsAddRange_SingleOptionIsNone_Returns_Empty_Errors()
    {
        var option = Option<Error>.None;

        var actual = Preconditions.AddRange(option);
        
        Assert.Empty(actual);  
    }
    
    [Fact]
    public void 
    PreconditionsAddRange_MultipleOptionsIsNone_Returns_Empty_Errors()
    {
        var options = new []
        {
            Option<Error>.None,
            Option<Error>.None,
            Option<Error>.None,
        };

        var actual = Preconditions.AddRange(options);
        
        Assert.Empty(actual);  
    }
    
    [Fact]
    public void 
    PreconditionsAddRange_SingleOptionIsSome_Returns_SingleError()
    {
        var expected = Error.Failure("MyCode", "Some description");
        var option =Option<Error>.Some(expected);

        var actual = Preconditions.AddRange(option).ToList();
        
        Assert.Single(actual);  
        Assert.Equal(expected, actual.First());  
    }
        
    [Fact]
    public void 
    PreconditionsAddRange_MultipleOptions_Only_SingleOptionIsSome_Returns_SingleError()
    {
        var expected = Error.Failure("MyCode", "Some description");
        var options = new []
        {
            Option<Error>.None,
            expected,
            Option<Error>.None,
        };

        var actual = Preconditions.AddRange(options).ToList();
        
        Assert.Single(actual);  
        Assert.Equal(expected, actual.First());  
    }
    
    [Fact]
    public void 
    PreconditionsAddRange_MultipleOptions_Only_MultipleOptionIsSome_Returns_Errors()
    {
        var expected1st = Error.Failure("MyCode1", "Some description1");
        var expected2nd = Error.Failure("MyCode2", "Some description2");
        var expected3rd = Error.Failure("MyCode3", "Some description3");
        var expected = new[] { expected1st, expected2nd, expected3rd };
        var options = new []
        {
            Option<Error>.Some(expected1st),
            Option<Error>.Some(expected2nd),
            Option<Error>.Some(expected3rd),
        };

        var actual = Preconditions.AddRange(options).ToList();
        
        Assert.Equal(3, actual.Count);  
        Assert.Equal(expected, actual);  
    }
    
    [Fact]
    public void 
    PreconditionsAddRange_MultipleOptions_Only_MultipleOptionIsSomeAndIsNone_Returns_Errors()
    {
        var expected1st = Error.Failure("MyCode1", "Some description1");
        var expected2nd = Error.Failure("MyCode2", "Some description2");
        var expected3rd = Error.Failure("MyCode3", "Some description3");
        var expected = new[] { expected1st, expected2nd, expected3rd };
        var options = new []
        {
            Option<Error>.None,
            expected1st,
            expected2nd,
            Option<Error>.None,
            expected3rd,
        };

        var actual = Preconditions.AddRange(options).ToList();
        
        Assert.Equal(3, actual.Count);  
        Assert.Equal(expected, actual);  
    }
}