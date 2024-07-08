namespace BrightSky.SharedKernel.Tests;

public class ResultExtensionsTests
{
    private class MyMockObject
    {
        public int MyIntProperty { get; set; }
    }
    
    [Fact]
    public void 
    When_ResultIsSuccess_And_Match_ThenAssert_ActualReturn_EqualsExpected()
    {
        var expected = "2";
        var result = Result<int, string>.Success(1);

        var actual = result.Match(
            value => (value + 1).ToString(),
            error => error);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void 
    When_ResultIsFailure_And_Match_ThenAssert_ActualReturn_EqualsError()
    {
        var expected = "Oops!";
        var result = Result<int, string>.Failure(expected);

        var actual = result.Match(
            value => (value + 1).ToString(),
            error => error);

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void 
    When_ResultIsSuccess_And_Match_ThenAssert_IsSuccess_EqualsTrue_And_Value_EqualsExpected()
    {
        var expected = 2;
        var result = Result<int, string>.Success(1);

        var actual = result.Match<int, string, Result<int, string>>(
            value => value + 1,
            error => error);

        Assert.True(actual.IsSuccess);
        Assert.Equal(expected, actual.Value);
    }

    [Fact]
    public void 
    When_ResultIsFailure_And_Match_ThenAssert_IsFailure_EqualsTrue_And_Error_EqualsExpected()
    {
        var expected = "Oops!";
        var result = Result<int, string>.Failure(expected);

        var actual = result.Match<int, string, Result<int, string>>(
            value => value + 1,
            error => error);

        Assert.True(actual.IsFailure);
        Assert.Equal(expected, actual.Error);
    }

    [Fact]
    public void 
    When_ResultIsSuccess_And_Bind_ThenAssert_IsSuccess_EqualsTrue_And_Value_EqualsExpected()
    {
        var expected = "2";
        var result = Result<int, string>.Success(1);

        var actual = result.Match<int, string, Result<int, string>>(
                value => value + 1,
                error => error)
            .Bind(value => Result<string, string>.Success(value.ToString()));

        Assert.True(actual.IsSuccess);
        Assert.Equal(expected, actual.Value);
    }

    [Fact]
    public void 
    When_ResultIsFailure_And_Bind_ThenAssert_IsFailure_EqualsTrue_And_Error_EqualsExpected()
    {
        var expected = "Oops!";
        var result = Result<int, string>.Failure(expected);

        var actual = result.Match<int, string, Result<int, string>>(
                value => value + 1,
                error => error)
            .Bind(value => Result<string, string>.Success(value.ToString()));

        Assert.True(actual.IsFailure);
        Assert.Equal(expected, actual.Error);
    }

    [Fact]
    public void 
    When_ResultIsSuccess_And_Ensure_ThenAssert_IsSuccess_EqualsTrue_And_Value_EqualsExpected()
    {
        var expected = 1;
        var result = Result<int, string>.Success(1);

        var actual = result
            .Ensure(value => value is 1, "Oops!");

        Assert.True(actual.IsSuccess);
        Assert.Equal(expected, actual.Value);
    }

    [Fact]
    public void 
    When_ResultIsFailure_And_Ensure_ThenAssert_IsFailure_EqualsTrue_And_Error_EqualsExpected()
    {
        var expected = "Oops!";
        var result = Result<int, string>.Failure(expected);

        var actual = result
            .Ensure(value => value is 1, expected);

        Assert.True(actual.IsFailure);
        Assert.Equal(expected, actual.Error);
    }

    [Fact]
    public void
    When_ResultIsSuccess_And_Ensure_WithPredicates_ThenAssert_IsSuccess_EqualsTrue_And_Value_EqualsExpected()
    {
        var expected = 1;
        var result = Result<int, string>.Success(1);

        var actual = result
            .Ensure(
                (value => value is 1, "Oops! 1"),
                (value => value > 0, "Oops! 2"),
                (value => value < 2, "Oops! 3"));

        Assert.True(actual.IsSuccess);
        Assert.Equal(expected, actual.Value);
    }

    [Fact]
    public void
    When_ResultIsFailure_And_Ensure_WithPredicates_ThenAssert_IsFailure_EqualsTrue_And_Error_EqualsExpected()
    {
        var expected = "Oops! 1";
        var result = Result<int, string>.Failure(expected);

        var actual = result
            .Ensure(
                (value => value is 1, expected),
                (value => value > 0, "Oops! 2"),
                (value => value < 2, "Oops! 3"));

        Assert.True(actual.IsFailure);
        Assert.Equal(expected, actual.Error);
    }

    [Fact]
    public void 
    When_ResultIsSuccess_And_Combine_ThenAssert_IsSuccess_EqualsTrue_And_Value_EqualsExpected()
    {
        var expected = 1;
        var results = new[]
        {
            Result<int, string>.Success(expected),
            Result<int, string>.Success(2)
        };

        var actual = results.Combine();

        Assert.True(actual.IsSuccess);
        Assert.Equal(expected, actual.Value);
    }

    [Fact]
    public void 
    When_ResultIsSuccess_And_Map_ThenAssert_IsSuccess_EqualsTrue_And_Value_EqualsExpected()
    {
        var expected = "2";
        var result = Result<int, string>.Success(1);

        var actual = result.Map(value => (value + 1).ToString());

        Assert.True(actual.IsSuccess);
        Assert.Equal(expected, actual.Value);
    }

    [Fact]
    public void 
    When_ResultIsFailure_And_Map_ThenAssert_IsFailure_EqualsTrue_And_Error_EqualsExpected()
    {
        var expected = "Oops!";
        var result = Result<int, string>.Failure(expected);

        var actual = result.Map(value => (value + 1).ToString());

        Assert.True(actual.IsFailure);
        Assert.Equal(expected, actual.Error);
    }

    [Fact]
    public void 
    When_ResultIsSuccess_And_Tap_ThenAssert_IsSuccess_EqualsTrue_And_Value_EqualsExpected()
    {
        var expected = 1;
        var stateObject = new MyMockObject();
        var result = Result<int, string>.Success(expected);

        var actual = result.Tap(value => { stateObject.MyIntProperty = value; });

        Assert.True(actual.IsSuccess);
        Assert.Equal(expected, actual.Value);
        Assert.Equal(expected, stateObject.MyIntProperty);
    }

    [Fact]
    public void 
    When_ResultIsFailure_And_Tap_ThenAssert_IsFailure_EqualsTrue_And_Error_EqualsExpected()
    {
        var expected = "Oops!";
        var mockObject = new MyMockObject();
        var result = Result<int, string>.Failure(expected);

        var actual = result.Tap(value => { mockObject.MyIntProperty = value; });

        Assert.True(actual.IsFailure);
        Assert.Equal(expected, actual.Error);
        Assert.Equal(default(int), mockObject.MyIntProperty);
    }
    
    [Fact]
    public void 
    When_ResultIsSuccess_And_TryCatch_WithCatchError_ThenAssert_IsSuccess_EqualsTrue_And_Value_EqualsExpected()
    {
        var expected = "2";
        var result = Result<int, string>.Success(1);

        var actual = result
            .TryCatch(value => (value + 1).ToString(), "Woo!");

        Assert.True(actual.IsSuccess);
        Assert.Equal(expected, actual.Value);
    }
    
    [Fact]
    public void 
    When_ResultIsFailure_And_TryCatch_WithCatchError_ThenAssert_IsFailure_EqualsTrue_And_Error_EqualsExpected()
    {
        var expected = "Oops!";
        var result = Result<int, string>.Failure(expected);

        var actual = result
            .TryCatch(value => (value + 1).ToString(), "Woo!");

        Assert.True(actual.IsFailure);
        Assert.Equal(expected, actual.Error);
    }
    
    [Fact]
    public void 
    When_ResultIsSuccess_And_TryCatch_WithCatchError_And_TryMap_ThrowsAnException_ThenAssert_IsFailure_EqualsTrue_And_Error_EqualsExpected()
    {
        var expected = "Woo!";
        var result = Result<int, string>.Success(1);

        var actual = result
            .TryCatch<int, string, string>(value => throw new Exception(), expected);

        Assert.True(actual.IsFailure);
        Assert.Equal(expected, actual.Error);
    }
    
    [Fact]
    public void 
    When_ResultIsSuccess_And_TryCatch_WithCatchMapException_ThenAssert_IsSuccess_EqualsTrue_And_Value_EqualsExpected()
    {
        var expected = "2";
        var result = Result<int, string>.Success(1);

        var actual = result
            .TryCatch(value => (value + 1).ToString(), e => e.Message);

        Assert.True(actual.IsSuccess);
        Assert.Equal(expected, actual.Value);
    }
    
    [Fact]
    public void 
    When_ResultIsFailure_And_TryCatch_WithCatchMapException_ThenAssert_IsFailure_EqualsTrue_And_Error_EqualsExpected()
    {
        var expected = "Oops!";
        var result = Result<int, string>.Failure(expected);

        var actual = result
            .TryCatch(value => (value + 1).ToString(), e => e.Message);

        Assert.True(actual.IsFailure);
        Assert.Equal(expected, actual.Error);
    }
    
    [Fact]
    public void 
    When_ResultIsSuccess_And_TryCatch_WithCatchMapException_And_TryMap_ThrowsAnException_ThenAssert_IsFailure_EqualsTrue_And_Error_EqualsExpected()
    {
        var expected = "Woo!";
        var result = Result<int, string>.Success(1);

        var actual = result
            .TryCatch<int, string, string>(value => throw new Exception(), e => expected);

        Assert.True(actual.IsFailure);
        Assert.Equal(expected, actual.Error);
    }
    
    [Fact]
    public void 
    When_ResultIsSuccess_And_TryCatch_WithCatchActionAndCatchError_ThenAssert_IsSuccess_EqualsTrue_And_Value_EqualsExpected()
    {
        var expected = "2";
        var result = Result<int, string>.Success(1);
        var catchAction = (Exception e) => { /*do nothing*/ };

        var actual = result
            .TryCatch(
                value => (value + 1).ToString(), 
                catchAction, 
                "Woo!");

        Assert.True(actual.IsSuccess);
        Assert.Equal(expected, actual.Value);
    }
    
    [Fact]
    public void 
    When_ResultIsFailure_And_TryCatch_WithCatchActionAndCatchError_ThenAssert_IsFailure_EqualsTrue_And_Error_EqualsExpected()
    {
        var expected = "Oops!";
        var result = Result<int, string>.Failure(expected);
        var catchAction = (Exception e) => { /*do nothing*/ };

        var actual = result
            .TryCatch(
                value => (value + 1).ToString(), 
                catchAction, 
                "Woo!");
        
        Assert.True(actual.IsFailure);
        Assert.Equal(expected, actual.Error);
    }
    
    [Fact]
    public void 
    When_ResultIsSuccess_And_TryCatch_WithCatchActionAndCatchError_And_TryMap_ThrowsAnException_ThenAssert_IsFailure_EqualsTrue_And_Error_EqualsExpected()
    {
        var expected = "Woo!";
        var result = Result<int, string>.Success(1);
        var catchAction = (Exception e) => { /*do nothing*/ };

        var actual = result
            .TryCatch<int, string, string>(
                value => throw new Exception(), 
                catchAction, 
                expected);
        
        Assert.True(actual.IsFailure);
        Assert.Equal(expected, actual.Error);
    }  
    
    [Fact]
    public void 
    When_ResultIsSuccess_And_TryCatch_WithCatchActionAndCatchMapException_ThenAssert_IsSuccess_EqualsTrue_And_Value_EqualsExpected()
    {
        var expected = "2";
        var result = Result<int, string>.Success(1);
        var catchAction = (Exception e) => { /*do nothing*/ };
        var catchMapException = (Exception e) => e.Message;

        var actual = result
            .TryCatch(
                value => (value + 1).ToString(), 
                catchAction, 
                catchMapException);

        Assert.True(actual.IsSuccess);
        Assert.Equal(expected, actual.Value);
    }
    
    [Fact]
    public void 
    When_ResultIsFailure_And_TryCatch_WithCatchActionAndCatchMapException_ThenAssert_IsFailure_EqualsTrue_And_Error_EqualsExpected()
    {
        var expected = "Oops!";
        var result = Result<int, string>.Failure(expected);
        var catchAction = (Exception e) => { /*do nothing*/ };
        var catchMapException = (Exception e) => e.Message;

        var actual = result
            .TryCatch(
                value => (value + 1).ToString(), 
                catchAction, 
                catchMapException);
        
        Assert.True(actual.IsFailure);
        Assert.Equal(expected, actual.Error);
    }
    
    [Fact]
    public void 
    When_ResultIsSuccess_And_TryCatch_WithCatchActionAndCatchMapException_And_TryMap_ThrowsAnException_ThenAssert_IsFailure_EqualsTrue_And_Error_EqualsExpected()
    {
        var expected = "Woo!";
        var result = Result<int, string>.Success(1);
        var catchAction = (Exception e) => { /*do nothing*/ };
        var catchMapException = (Exception e) => expected;

        var actual = result
            .TryCatch<int, string, string>(
                value => throw new Exception(), 
                catchAction, 
                catchMapException);
        
        Assert.True(actual.IsFailure);
        Assert.Equal(expected, actual.Error);
    }
}