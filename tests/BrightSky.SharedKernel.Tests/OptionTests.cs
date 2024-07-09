namespace BrightSky.SharedKernel.Tests;

public class OptionTests
{
    [Fact]
    public void When_OptionSome_WithString_ThenAssert_IsSome_EqualsTrue()
    {
        var option = Option<string>.Some("some string");
        
        Assert.True(option.IsSome);
    }
    
    [Fact]
    public void When_OptionSome_WithString_ThenAssert_IsNone_EqualsFalse()
    {
        var option = Option<string>.Some("some string");
        
        Assert.False(option.IsNone);
    }
    
    [Fact]
    public void When_OptionSome_WithString_ThenAssert_Value_EqualsExpected()
    {
        var expected = "some string";
        var option = Option<string>.Some(expected);
        
        Assert.Equal(expected, option.Value);
    }
    
    [Fact]
    public void When_OptionNone_WithString_ThenAssert_IsSome_EqualsFalse()
    {
        var option = Option<string>.None;
        
        Assert.False(option.IsSome);
    }
    
    [Fact]
    public void When_OptionNone_WithString_ThenAssert_IsNone_EqualsTrue()
    {
        var option = Option<string>.None;
        
        Assert.True(option.IsNone);
    }
    
    [Fact]
    public void When_OptionNone_WithString_ThenAssert_Value_ThrowsNullReferenceException()
    {
        var option = Option<string>.None;
        
        Assert.Throws<NullReferenceException>(() => option.Value);
    }
    
    [Fact]
    public void When_Option_WithString_ThenAssert_ImplicitOperator_EqualsExpected()
    {
        var value = "some string";
        var option = (Option<string>)value;
        
        Assert.IsType<Option<string>>(option);
        Assert.Equal(value, option.Value);
        Assert.True(option.IsSome);
        Assert.False(option.IsNone);
    }
    
    [Fact]
    public void When_OptionSome_WithInt_ThenAssert_IsSome_EqualsTrue()
    {
        var option = Option<int>.Some(123);
        
        Assert.True(option.IsSome);
    }
    
    [Fact]
    public void When_OptionSome_WithInt_ThenAssert_IsNone_EqualsFalse()
    {
        var option = Option<int>.Some(123);
        
        Assert.False(option.IsNone);
    }
    
    [Fact]
    public void When_OptionSome_WithInt_ThenAssert_Value_EqualsExpected()
    {
        var expected = 123;
        var option = Option<int>.Some(expected);
        
        Assert.Equal(expected, option.Value);
    }
    
    
    [Fact]
    public void When_OptionNone_WithInt_ThenAssert_IsSome_EqualsFalse()
    {
        var option = Option<int>.None;
        
        Assert.False(option.IsSome);
    }
    
    [Fact]
    public void When_OptionNone_WithInt_ThenAssert_IsNone_EqualsTrue()
    {
        var option = Option<int>.None;
        
        Assert.True(option.IsNone);
    }
    
    [Fact]
    public void When_OptionNone_WithInt_ThenAssert_Value_ThrowsNullReferenceException()
    {
        var option = Option<int>.None;
        
        Assert.Throws<NullReferenceException>(() => option.Value);
    }
    
    [Fact]
    public void When_Option_WithInt_ThenAssert_ImplicitOperator_EqualsExpected()
    {
        var value = 123;
        var option = (Option<int>)value;
        
        Assert.IsType<Option<int>>(option);
        Assert.Equal(value, option.Value);
        Assert.True(option.IsSome);
        Assert.False(option.IsNone);
    }
}