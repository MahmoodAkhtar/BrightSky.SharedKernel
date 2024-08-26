using System.Linq.Expressions;

namespace BrightSky.SharedKernel.Tests;

public class EnumerationTests
{
    public record struct HexCode
    {
        private static readonly Specification<string?> HexCodeSpec = new HexCodeSpecification();
        
        private readonly string _value;
        
        private HexCode(string value) =>
            _value = Precondition.Requires(value).Meets(HexCodeSpec!).ThenAssignOrThrow<string, ArgumentException>();
        
        public static HexCode Create(string value) => new(value);

        public static implicit operator string(HexCode value) => value._value;
        public static explicit operator HexCode(string value) => Create(value);

        private class HexCodeSpecification : Specification<string?>
        {
            public override Expression<Func<string?, bool>> ToExpression()
                => s => !string.IsNullOrWhiteSpace(s) 
                        && s.Length == 7 
                        && s.StartsWith('#') 
                        && s.ToUpper().All(c => "#0123456789ABCDEF".Contains(c));
        }

    }
    
    public record HtmlColor : Enumeration<HtmlColor, HexCode>
    {
        public static HtmlColor IndianRed => new HtmlColor(nameof(IndianRed), HexCode.Create("#CD5C5C"));
        public static HtmlColor LightCoral => new HtmlColor(nameof(LightCoral), HexCode.Create("#F08080"));
        public static HtmlColor Salmon => new HtmlColor(nameof(Salmon), HexCode.Create("#FA8072"));
        
        private HtmlColor(string name, HexCode value) : base(name, value)
        {
        }
    }
    
    [Fact]
    public void EnumerationTest1()
    {
        var hc = HtmlColor.IndianRed;

        Assert.IsAssignableFrom<Enumeration<HtmlColor, HexCode>>(hc);
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