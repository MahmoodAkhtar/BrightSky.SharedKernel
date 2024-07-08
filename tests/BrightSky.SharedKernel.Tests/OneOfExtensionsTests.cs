using System.Globalization;

namespace BrightSky.SharedKernel.Tests;

public class OneOfExtensionsTests
{
    private class MyMockObject
    {
        public int MyIntProperty { get; set; }
        public decimal MyDecimalProperty { get; set; }
    }

    [Fact]
    public void When_Case_T1_And_Match_ThenAssert_ActualReturn_EqualsExpected()
    {
        var oneOf = OneOf<int, decimal>.Case(1);

        var actual = oneOf.Match(
            c1 => c1,
            c2 => 0);
        
        Assert.Equal(1, actual);
    }
    
    [Fact]
    public void When_Case_T1_And_Tap_ThenAssert_ActualReturn_EqualsExpected()
    {
        var oneOf = OneOf<int, decimal>.Case(1);
        var stateObject = new MyMockObject();

        var actual = oneOf.Tap(
            c1 => { stateObject.MyIntProperty = c1; },
            c2 =>
            {
                /* do nothing */
            });

        Assert.Equal(1, actual);
        Assert.Equal(1, stateObject.MyIntProperty);
    }

    [Fact]
    public void When_Case_T1_And_Map_ThenAssert_ActualReturn_EqualsExpected()
    {
        var oneOf = OneOf<int, decimal>.Case(1);

        var actual = oneOf.Map(
            c1 => c1 == 1,
            c2 => c2.ToString(CultureInfo.InvariantCulture));

        Assert.Equal(true, actual);
    }

    [Fact]
    public void When_Case_T1_And_Bind_ThenAssert_ActualReturn_EqualsExpected()
    {
        var oneOf = OneOf<int, decimal>.Case(1);

        var actual = oneOf.Bind(
            c1 => OneOf<bool, string>.Case(c1 == 1),
            c2 => OneOf<bool, string>.Case(c2.ToString(CultureInfo.InvariantCulture)));

        Assert.Equal(true, actual);
    }

    [Fact]
    public void When_Case_T2_ThenAssert_ImplicitOperator_EqualsExpected()
    {
        var actual = OneOf<int, decimal>.Case(1.123m);

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
    public void When_Case_T2_And_Tap_ThenAssert_ActualReturn_EqualsExpected()
    {
        var oneOf = OneOf<int, decimal>.Case(1.123m);
        var stateObject = new MyMockObject();

        var actual = oneOf.Tap(
            c1 =>
            {
                /* do nothing */
            },
            c2 => { stateObject.MyDecimalProperty = c2; });

        Assert.Equal(1.123m, actual);
        Assert.Equal(1.123m, stateObject.MyDecimalProperty);
    }

    [Fact]
    public void When_Case_T2_And_Map_ThenAssert_ActualReturn_EqualsExpected()
    {
        var oneOf = OneOf<int, decimal>.Case(1.123m);

        var actual = oneOf.Map(
            c1 => c1 == 1,
            c2 => c2.ToString(CultureInfo.InvariantCulture));

        Assert.Equal("1.123", actual);
    }

    [Fact]
    public void When_Case_T2_And_Bind_ThenAssert_ActualReturn_EqualsExpected()
    {
        var oneOf = OneOf<int, decimal>.Case(1.123m);

        var actual = oneOf.Bind(
            c1 => OneOf<bool, string>.Case(c1 == 1),
            c2 => OneOf<bool, string>.Case(c2.ToString(CultureInfo.InvariantCulture)));

        Assert.Equal("1.123", actual);
    }
}