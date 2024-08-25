namespace BrightSky.SharedKernel.Tests;

public class EnumerationTests
{
    public record HtmlColor : Enumeration<HtmlColor, string>
    {
        public static HtmlColor IndianRed => new HtmlColor(nameof(IndianRed), "#CD5C5C");
        public static HtmlColor LightCoral => new HtmlColor(nameof(LightCoral), "#F08080");
        public static HtmlColor Salmon => new HtmlColor(nameof(Salmon), "#FA8072");
        
        private HtmlColor(string name, string value) : base(name, value)
        {
        }
    }
    
    [Fact]
    public void EnumerationTest1()
    {
        var hc = HtmlColor.IndianRed;

        Assert.IsAssignableFrom<Enumeration<HtmlColor, string>>(hc);
    }
    
    [Fact]
    public void EnumerationTest2()
    {
        var hc1 = HtmlColor.IndianRed;
        var hc2 = HtmlColor.IndianRed;

        Assert.Equal<HtmlColor>(hc1, hc2);
    }
    
    [Fact]
    public void EnumerationTest3()
    {
        var hc1 = HtmlColor.IndianRed;
        var op = HtmlColor.FromValue(hc1.Value);
        var assert = op.Match<HtmlColor, Action>(
            some => () => Assert.Equal(hc1, some), 
            () => () => Assert.Fail());

        assert();
    }    
    
    [Fact]
    public void EnumerationTest4()
    {
        var hc1 = HtmlColor.IndianRed;
        var op = HtmlColor.FromName(hc1.Name);
        var assert = op.Match<HtmlColor, Action>(
            some => () => Assert.Equal(hc1, some), 
            () => () => Assert.Fail());

        assert();
    }
}