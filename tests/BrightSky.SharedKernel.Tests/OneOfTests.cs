using System.Security.Cryptography.X509Certificates;

namespace BrightSky.SharedKernel.Tests;

public class OneOfTests
{
    [Fact]
    public void When_Case_T1_ThenAssert_ImplicitOperator_EqualsExpected()
    {
        var actual = OneOf<int, decimal>.Case(1);
        
        Assert.Equal(1, actual);
    }
    
    [Fact]
    public void When_Case_T1_ThenAssert_ExplicitOperator_EqualsExpected()
    {
        var actual = (int)OneOf<int, decimal>.Case(1);
        
        Assert.Equal(1, actual);
    }
    
    [Fact]
    public void When_Case_T1_ThenAssert_TryGet_ReturnsTrue_And_Out_EqualsExpected()
    {
        var oneOf = OneOf<int, decimal>.Case(1);
    
        var actual = oneOf.TryGet(out int outActual);
        
        Assert.True(actual);
        Assert.Equal(1, outActual);
    }
    
    [Fact]
    public void When_Case_T1_ThenAssert_TryGet_ReturnsFalse_And_Out_EqualsDefault()
    {
        var oneOf = OneOf<int, decimal>.Case(1);
    
        var actual = oneOf.TryGet(out string outActual);
        
        Assert.False(actual);
        Assert.Equal(default, outActual);
    }
    
    [Fact]
    public void When_Case_T1_ThenAssert_TryGet_EqualsExpected()
    {
        var oneOf = OneOf<int, decimal>.Case(1);
    
        var actual = oneOf.TryGet(out int outActual);
        
        Assert.True(actual);
        Assert.Equal(1, outActual);
    }
    
    [Fact]
    public void When_Case_T2_ThenAssert_ImplicitOperator_EqualsExpected()
    {
        var actual = OneOf<int, decimal>.Case(1.123m);
        
        Assert.Equal(1.123m, actual);
    }
    
    [Fact]
    public void When_Case_T2_ThenAssert_ExplicitOperator_EqualsExpected()
    {
        var actual = (decimal)OneOf<int, decimal>.Case(1.123m);
        
        Assert.Equal(1.123m, actual);
    }
    
    [Fact]
    public void When_Case_T2_And_Match_ThenAssert_ActualReturn_EqualsExpected()
    {
        var oneOf = OneOf<int, decimal>.Case(1.123m);
    
        var actual = oneOf.Match(
            c1 => c1,
            c2 => c2);
        
        Assert.Equal(1.123m, actual);
    }
        
    [Fact]
    public void When_Case_T2_ThenAssert_TryGet_ReturnsTrue_And_Out_EqualsExpected()
    {
        var oneOf = OneOf<int, decimal>.Case(1.123m);
    
        var actual = oneOf.TryGet(out decimal outActual);
        
        Assert.True(actual);
        Assert.Equal(1.123m, outActual);
    }
            
    [Fact]
    public void When_Case_T2_ThenAssert_TryGet_ReturnsFalse_And_Out_EqualsDefault()
    {
        var oneOf = OneOf<int, decimal>.Case(1.123m);
    
        var actual = oneOf.TryGet(out string outActual);
        
        Assert.False(actual);
        Assert.Equal(default, outActual);
    }
}