namespace BrightSky.SharedKernel.Tests;

public class ResultTests
{
    [Fact]
    public void When_ResultIsSuccess_ThenAssert_IsSuccess_EqualsTrue()
    {
        var result = Result<int, string>.Success(1);
        
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public void When_ResultIsSuccess_ThenAssert_IsFailure_EqualsFalse()
    {
        var result = Result<int, string>.Success(1);
        
        Assert.False(result.IsFailure);
    }
    
    [Fact]
    public void When_ResultIsSuccess_ThenAssert_Value_EqualsExpected()
    {
        var result = Result<int, string>.Success(1);
        
        Assert.Equal(1, result.Value);
    }
    
    [Fact]
    public void When_ResultIsSuccess_ThenAssert_Error_IsDefault()
    {
        var result = Result<int, string>.Success(1);
        
        Assert.Equal(default(string), result.Error);
    }
    
    [Fact]
    public void When_ResultIsFailure_ThenAssert_IsSuccess_EqualsFalse()
    {
        var result = Result<int, string>.Failure("Oops!");
        
        Assert.False(result.IsSuccess);
    }
    
    [Fact]
    public void When_ResultIsFailure_ThenAssert_IsFailure_EqualsTrue()
    {
        var result = Result<int, string>.Failure("Oops!");
        
        Assert.True(result.IsFailure);
    }
    
    [Fact]
    public void When_ResultIsFailure_ThenAssert_Value_IsDefault()
    {
        var result = Result<int, string>.Failure("Oops!");
        
        Assert.Equal(default(int), result.Value);
    }
    
    [Fact]
    public void When_ResultIsFailure_ThenAssert_Error_EqualsExpected()
    {
        var expected = "Oops!";
        var result = Result<int, string>.Failure(expected);
        
        Assert.Equal(expected, result.Error);
    }
    
    [Fact]
    public void When_ResultIsSuccess_ThenAssert_Success_ImplicitOperator_EqualsExpected()
    {
        var result = Result<int, string>.Success(1);
        
        Assert.Equal(1, result);
    }
        
    [Fact]
    public void When_ResultIsFailure_ThenAssert_Failure_ImplicitOperator_EqualsExpected()
    {
        var expected = "Oops!";
        var result = Result<int, string>.Failure(expected);
        
        Assert.Equal(expected, result);
    }
}