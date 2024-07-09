namespace BrightSky.SharedKernel.Tests;

public class OptionTests
{
    [Fact]
    public void When_OptionSome_ThenAssert_IsSome_EqualsTrue()
    {
        var option = Option<string>.Some("some string");
        
        Assert.True(option.IsSome);
    }
    
    [Fact]
    public void When_OptionSome_ThenAssert_IsNone_EqualsFalse()
    {
        var option = Option<string>.Some("some string");
        
        Assert.False(option.IsNone);
    }
    
    [Fact]
    public void When_OptionSome_ThenAssert_Value_EqualsExpected()
    {
        var expected = "some string";
        var option = Option<string>.Some(expected);
        
        Assert.Equal(expected, option.Value);
    }
    
    [Fact]
    public void When_OptionNone_ThenAssert_IsSome_EqualsFalse()
    {
        var option = Option<string>.None();
        
        Assert.False(option.IsSome);
    }
    
    [Fact]
    public void When_OptionNone_ThenAssert_IsNone_EqualsTrue()
    {
        var option = Option<string>.None();
        
        Assert.True(option.IsNone);
    }
    
    [Fact]
    public void When_OptionNone_ThenAssert_Value_ThrowsNullReferenceException()
    {
        var option = Option<string>.None();
        var func = () => option.Value;
        
        Assert.Throws<NullReferenceException>(func);
    }
    
    [Fact]
    public void When_Option_ThenAssert_ImplicitOperator_EqualsExpected()
    {
        var value = "some string";
        var option = (Option<string>)value;
        
        Assert.IsType<Option<string>>(option);
        Assert.Equal(value, option.Value);
        Assert.True(option.IsSome);
        Assert.False(option.IsNone);
    }
}