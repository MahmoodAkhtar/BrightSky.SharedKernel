namespace BrightSky.SharedKernel.Tests;

public class OptionExtensionsTests
{
    private class MyMockObject
    {
        public int MyIntProperty { get; set; }
    }
    
    [Fact]
    public void 
    When_OptionIsSome_And_Map_ThenAssert_IsSome_EqualsTrue_And_Value_EqualsExpected()
    {
        var expected = "2";
        var option = Option<int>.Some(1);

        var actual = option
            .Map(value => (value +1).ToString());
        
        Assert.True(actual.IsSome);
        Assert.Equal(expected, actual.Value);
    }
    
    [Fact]
    public void 
    When_OptionIsNone_And_Map_ThenAssert_IsNone_EqualsTrue_And_Value_ThrowsNullReferenceException()
    {
        var option = Option<int>.None;

        var actual = option
            .Map(value => (value +1).ToString());
        
        Assert.True(actual.IsNone);
        Assert.Throws<NullReferenceException>(() => actual.Value);
    }
    
    [Fact]
    public void 
    When_OptionIsSome_And_Tap_ThenAssert_IsSome_EqualsTrue_And_Value_EqualsExpected()
    {
        var expected = 1;
        var stateObject = new MyMockObject();
        var option = Option<int>.Some(expected);

        var actual = option.Tap(value => { stateObject.MyIntProperty = value; });

        Assert.True(actual.IsSome);
        Assert.Equal(expected, actual.Value);
        Assert.Equal(expected, stateObject.MyIntProperty);
    }
    
    [Fact]
    public void 
    When_OptionIsNone_And_Tap_ThenAssert_IsNone_EqualsTrue__And_Value_ThrowsNullReferenceException()
    {
        var mockObject = new MyMockObject();
        var option = Option<int>.None;

        var actual = option.Tap(value => { mockObject.MyIntProperty = value; });

        Assert.True(actual.IsNone);
        Assert.Equal(Option<int>.None, actual);
        Assert.Equal(default(int), mockObject.MyIntProperty);
    }    
    
    [Fact]
    public void 
    When_OptionIsSome_And_Bind_ThenAssert_IsSome_EqualsTrue_And_Value_EqualsExpected()
    {
        var expected = "2";
        var option = Option<int>.Some(1);

        var actual = option
            .Bind(value => Option<string>.Some((value +1).ToString()));
        
        Assert.True(actual.IsSome);
        Assert.Equal(expected, actual.Value);
    }
    
    [Fact]
    public void 
    When_OptionIsNone_And_Bind_ThenAssert_IsNone_EqualsTrue_And_Value_ThrowsNullReferenceException()
    {
        var option = Option<int>.None;

        var actual = option
            .Bind(value => Option<string>.Some((value +1).ToString()));
        
        Assert.True(actual.IsNone);
        Assert.Throws<NullReferenceException>(() => actual.Value);
    }
    
        
    [Fact]
    public void 
    When_OptionIsSome_And_Reduce_ThenAssert_Actual_EqualsExpected()
    {
        var expected = 1;
        var option = Option<int>.Some(expected);

        var actual = option.Reduce(2);
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void 
    When_OptionIsNone_And_Reduce_ThenAssert_Actual_EqualsExpected()
    {
        var expected = 2;
        var option = Option<int>.None;

        var actual = option.Reduce(expected);
        
        Assert.Equal(expected, actual);
    }
}