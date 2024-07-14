namespace BrightSky.SharedKernel.Tests.Codabar;

public class Tests
{
    private static PrintOptions Options => PrintOptions.Create(
        BarPrintOptions.Create("|", "["),
        SpacePrintOptions.Create(" ", "  "));
    
    [Fact]
    public void Char0Print_AsExpected()
    {
        var expected = "| | |  [";
        var c = Char0.Create();
        
        var actual = c.Print(Options);
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Char1Print_AsExpected()
    {
        var expected = "| | [  |";
        var c = Char1.Create();
        
        var actual = c.Print(Options);
        
        Assert.Equal(expected, actual);
    }
        
    [Fact]
    public void Char2Print_AsExpected()
    {
        var expected = "| |  | [";
        var c = Char2.Create();
        
        var actual = c.Print(Options);
        
        Assert.Equal(expected, actual);
    }
}