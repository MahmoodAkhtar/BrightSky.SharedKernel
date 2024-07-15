namespace BrightSky.SharedKernel.Tests.Codabar;

// See: https://www.lido.app/inventory/codabar-barcode
// See: https://web.archive.org/web/20160415005614/http://www.barcodeman.com/info/codabar.php
// See: https://en.wikipedia.org/wiki/Codabar

public readonly record struct WideBar;
public readonly record struct NarrowBar;
public readonly record struct WideSpace;
public readonly record struct NarrowSpace;

public record Bar : OneOf<WideBar, NarrowBar>
{
    public static WideBar WideBar => new();
    public static NarrowBar NarrowBar => new();
    
    public new static Bar Case(WideBar bar) => new(bar); 
    public new static Bar Case(NarrowBar bar) => new(bar); 
    
    public static implicit operator Bar(WideBar bar) => new(bar); 
    public static implicit operator Bar(NarrowBar bar) => new(bar); 
    
    public static implicit operator WideBar(Bar bar) => bar.Get<WideBar>(); 
    public static implicit operator NarrowBar(Bar bar) => bar.Get<NarrowBar>(); 

    protected Bar(WideBar value) : base(value)
    {
    }

    protected Bar(NarrowBar value) : base(value)
    {
    }
}

public record Space : OneOf<WideSpace, NarrowSpace>
{
    public static WideSpace WideSpace => new();
    public static NarrowSpace NarrowSpace => new();
    
    public new static Space Case(WideSpace space) => new(space); 
    public new static Space Case(NarrowSpace space) => new(space); 
    
    public static implicit operator Space(WideSpace space) => new(space); 
    public static implicit operator Space(NarrowSpace space) => new(space); 
    
    public static implicit operator WideSpace(Space space) => space.Get<WideSpace>(); 
    public static implicit operator NarrowSpace(Space space) => space.Get<NarrowSpace>(); 

    protected Space(WideSpace value) : base(value)
    {
    }

    protected Space(NarrowSpace value) : base(value)
    {
    }
}

public readonly record struct Pattern(
    Bar First,
    Space Second,
    Bar Third,
    Space Fourth,
    Bar Fifth,
    Space Sixth,
    Bar Seventh)
{
    public static Pattern Char0 => new(Bar.NarrowBar, Space.NarrowSpace, Bar.NarrowBar, Space.NarrowSpace, Bar.NarrowBar, Space.WideSpace,   Bar.WideBar);
    public static Pattern Char1 => new(Bar.NarrowBar, Space.NarrowSpace, Bar.NarrowBar, Space.NarrowSpace, Bar.WideBar,   Space.WideSpace,   Bar.NarrowBar);
    public static Pattern Char2 => new(Bar.NarrowBar, Space.NarrowSpace, Bar.NarrowBar, Space.WideSpace,   Bar.NarrowBar, Space.NarrowSpace, Bar.WideBar);
    public static Pattern Char3 => new(Bar.WideBar,   Space.WideSpace,   Bar.NarrowBar, Space.NarrowSpace, Bar.NarrowBar, Space.NarrowSpace, Bar.NarrowBar);
    public static Pattern Char4 => new(Bar.NarrowBar, Space.NarrowSpace, Bar.WideBar,   Space.NarrowSpace, Bar.NarrowBar, Space.WideSpace,   Bar.NarrowBar);
    public static Pattern Char5 => new(Bar.WideBar,   Space.NarrowSpace, Bar.NarrowBar, Space.NarrowSpace, Bar.NarrowBar, Space.WideSpace,   Bar.NarrowBar);
    public static Pattern Char6 => new(Bar.NarrowBar, Space.WideSpace,   Bar.NarrowBar, Space.NarrowSpace, Bar.NarrowBar, Space.NarrowSpace, Bar.WideBar);
    public static Pattern Char7 => new(Bar.NarrowBar, Space.WideSpace,   Bar.NarrowBar, Space.NarrowSpace, Bar.WideBar,   Space.NarrowSpace, Bar.NarrowBar);
    public static Pattern Char8 => new(Bar.NarrowBar, Space.WideSpace,   Bar.WideBar,   Space.NarrowSpace, Bar.NarrowBar, Space.NarrowSpace, Bar.NarrowBar);
    public static Pattern Char9 => new(Bar.WideBar,   Space.NarrowSpace, Bar.NarrowBar, Space.WideSpace,   Bar.NarrowBar, Space.NarrowSpace, Bar.NarrowBar);

    public static Pattern CharHyphen =>       new(Bar.NarrowBar, Space.NarrowSpace, Bar.NarrowBar, Space.WideSpace,   Bar.WideBar  , Space.NarrowSpace, Bar.NarrowBar);
    public static Pattern CharDollar =>       new(Bar.NarrowBar, Space.NarrowSpace, Bar.WideBar,   Space.WideSpace,   Bar.NarrowBar, Space.NarrowSpace, Bar.NarrowBar);
    public static Pattern CharColon =>        new(Bar.WideBar,   Space.NarrowSpace, Bar.NarrowBar, Space.NarrowSpace, Bar.WideBar  , Space.NarrowSpace, Bar.WideBar);
    public static Pattern CharForwardSlash => new(Bar.WideBar,   Space.NarrowSpace, Bar.WideBar  , Space.NarrowSpace, Bar.NarrowBar, Space.NarrowSpace, Bar.WideBar);
    public static Pattern CharDot =>          new(Bar.WideBar,   Space.NarrowSpace, Bar.WideBar,   Space.NarrowSpace, Bar.WideBar,   Space.NarrowSpace, Bar.NarrowBar);
    public static Pattern CharPlus =>         new(Bar.NarrowBar, Space.NarrowSpace, Bar.WideBar,   Space.NarrowSpace, Bar.WideBar,   Space.NarrowSpace, Bar.WideBar);

    public static Pattern CharA => new(Bar.NarrowBar, Space.NarrowSpace, Bar.WideBar,   Space.WideSpace,   Bar.NarrowBar, Space.WideSpace,   Bar.NarrowBar);
    public static Pattern CharB => new(Bar.NarrowBar, Space.WideSpace,   Bar.NarrowBar, Space.WideSpace,   Bar.NarrowBar, Space.NarrowSpace, Bar.WideBar);
    public static Pattern CharC => new(Bar.NarrowBar, Space.NarrowSpace, Bar.NarrowBar, Space.WideSpace,   Bar.NarrowBar, Space.WideSpace,   Bar.WideBar);
    public static Pattern CharD => new(Bar.NarrowBar, Space.NarrowSpace, Bar.NarrowBar, Space.WideSpace,   Bar.WideBar,   Space.WideSpace, Bar.NarrowBar);

    public static Pattern CharT =>    new(Bar.NarrowBar, Space.NarrowSpace, Bar.WideBar,   Space.WideSpace,   Bar.NarrowBar, Space.WideSpace,   Bar.NarrowBar);
    public static Pattern CharN =>    new(Bar.NarrowBar, Space.WideSpace,   Bar.NarrowBar, Space.WideSpace,   Bar.NarrowBar, Space.NarrowSpace, Bar.WideBar);
    public static Pattern CharStar => new(Bar.NarrowBar, Space.NarrowSpace, Bar.NarrowBar, Space.WideSpace,   Bar.NarrowBar, Space.WideSpace,   Bar.WideBar);
    public static Pattern CharE =>    new(Bar.NarrowBar, Space.NarrowSpace, Bar.NarrowBar, Space.WideSpace,   Bar.WideBar,   Space.WideSpace,   Bar.NarrowBar);
}

public static class PatternExtensions
{
    private static string Print(this Space space, SpacePrintOptions options)
        => space.Match(c1 => options.Wide, c2 => options.Narrow);

    private static string Print(this Bar bar, BarPrintOptions options)
        => bar.Match(c1 => options.Wide, c2 => options.Narrow);

    public static string Print(this Pattern pattern, PrintOptions options)
        => $"{pattern.First.Print(options.BarPrintOptions)}{pattern.Second.Print(options.SpacePrintOptions)}{pattern.Third.Print(options.BarPrintOptions)}{pattern.Fourth.Print(options.SpacePrintOptions)}{pattern.Fifth.Print(options.BarPrintOptions)}{pattern.Sixth.Print(options.SpacePrintOptions)}{pattern.Seventh.Print(options.BarPrintOptions)}";
}

public interface ICodabarChar
{
    char Char { get; }
    Pattern Pattern { get; }
}

public static class ICodabarCharExtensions
{
    public static string Print(this ICodabarChar @char, PrintOptions options)
        => @char.Pattern.Print(options);
}

public readonly record struct BarPrintOptions
{
    public string Narrow { get; init; }
    public string Wide { get; init; }

    private BarPrintOptions(string narrow, string wide)
    {
        Narrow = narrow;
        Wide = wide;
    }

    public static BarPrintOptions Create(string narrow, string wide) => new(narrow, wide);
}

public readonly record struct SpacePrintOptions
{
    public string Narrow { get; init; }
    public string Wide { get; init; }

    private SpacePrintOptions(string narrow, string wide)
    {
        Narrow = narrow;
        Wide = wide;
    }

    public static SpacePrintOptions Create(string narrow, string wide) => new(narrow, wide);
}

public readonly record struct PrintOptions
{
    public BarPrintOptions BarPrintOptions { get; init; }
    public SpacePrintOptions SpacePrintOptions { get; init; }

    private PrintOptions(BarPrintOptions barPrintOptions, SpacePrintOptions spacePrintOptions)
    {
        BarPrintOptions = barPrintOptions;
        SpacePrintOptions = spacePrintOptions;
    }

    public static PrintOptions Create(BarPrintOptions barPrintOptions, SpacePrintOptions spacePrintOptions)
        => new(barPrintOptions, spacePrintOptions);
}

public readonly record struct Char0 : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private Char0(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static Char0 Create() => new('0', Pattern.Char0);
}

public readonly record struct Char1 : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private Char1(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static Char1 Create() => new('1', Pattern.Char1);
}

public readonly record struct Char2 : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private Char2(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static Char2 Create() => new('2', Pattern.Char2);
}

public readonly record struct Char3 : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private Char3(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static Char3 Create() => new('3', Pattern.Char3);
}

public readonly record struct Char4 : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private Char4(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static Char4 Create() => new('4', Pattern.Char4);
}

public readonly record struct Char5 : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private Char5(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static Char5 Create() => new('5', Pattern.Char5);
}

public readonly record struct Char6 : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private Char6(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static Char6 Create() => new('6', Pattern.Char6);
}

public readonly record struct Char7 : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private Char7(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static Char7 Create() => new('7', Pattern.Char7);
}

public readonly record struct Char8 : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private Char8(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static Char8 Create() => new('8', Pattern.Char8);
}

public readonly record struct Char9 : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private Char9(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static Char9 Create() => new('9', Pattern.Char9);
}

public readonly record struct CharA : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private CharA(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static CharA Create() => new('A', Pattern.CharA);
}

public readonly record struct CharB : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private CharB(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static CharB Create() => new('B', Pattern.CharB);
}

public readonly record struct CharC : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private CharC(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static CharC Create() => new('C', Pattern.CharC);
}

public readonly record struct CharD : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private CharD(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static CharD Create() => new('D', Pattern.CharD);
}

public readonly record struct CharT : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private CharT(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static CharT Create() => new('T', Pattern.CharT);
}

public readonly record struct CharN : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private CharN(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static CharN Create() => new('N', Pattern.CharN);
}

public readonly record struct CharStar : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private CharStar(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static CharStar Create() => new('*', Pattern.CharStar);
}

public readonly record struct CharE : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private CharE(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static CharE Create() => new('E', Pattern.CharE);
}

public readonly record struct CharHyphen : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private CharHyphen(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static CharHyphen Create() => new('-', Pattern.CharHyphen);
}

public readonly record struct CharDollar : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private CharDollar(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static CharDollar Create() => new('$', Pattern.CharDollar);
}

public readonly record struct CharColon : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private CharColon(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static CharColon Create() => new(':', Pattern.CharColon);
}

public readonly record struct CharForwardSlash : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private CharForwardSlash(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static CharForwardSlash Create() => new('/', Pattern.CharForwardSlash);
}

public readonly record struct CharDot : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private CharDot(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static CharDot Create() => new('.', Pattern.CharDot);
}

public readonly record struct CharPlus : ICodabarChar
{
    public char Char { get; }
    public Pattern Pattern { get; init; }

    private CharPlus(char @char, Pattern pattern) => (Char, Pattern) = (@char, pattern);

    public static CharPlus Create() => new('+', Pattern.CharPlus);
}

public readonly record struct CodabarBarcode
{
    public IReadOnlyList<ICodabarChar> Chars { get; init; }

    private CodabarBarcode(IReadOnlyList<ICodabarChar> @chars)
    {
        Chars = @chars;
    }

    private static CodabarBarcode Create(params ICodabarChar[] @chars) => new(@chars);

    public static Option<CodabarBarcode> TryCreate(string chars)
    {
        var array = chars
            .ToCharArray()
            .Where(CodabarChars.IsCodabarChar)
            .Select(CodabarChars.TryGet)
            .Where(o => o.IsSome)
            .Select(o => o.Value)
            .ToArray();
        
        return array.Length > 0 ? Create(array) : Option<CodabarBarcode>.None;
    }
}

public static class CodabarBarcodeExtensions
{
    public static string Print(this Option<CodabarBarcode> barcode, PrintOptions options)
        => barcode.Match(some => some.Print(options), () => string.Empty);    
    
    private static string Print(this CodabarBarcode barcode, PrintOptions options)
        => string.Join(options.SpacePrintOptions.Narrow, barcode.Chars.Select(c => c.Print(options)));
}

public static class CodabarChars
{
    private static readonly Char0      Char0 =      Char0.Create();
    private static readonly Char1      Char1 =      Char1.Create();
    private static readonly Char2      Char2 =      Char2.Create();
    private static readonly Char3      Char3 =      Char3.Create();
    private static readonly Char4      Char4 =      Char4.Create();
    private static readonly Char5      Char5 =      Char5.Create();
    private static readonly Char6      Char6 =      Char6.Create();
    private static readonly Char7      Char7 =      Char7.Create();
    private static readonly Char8      Char8 =      Char8.Create();
    private static readonly Char9      Char9 =      Char9.Create();
    private static readonly CharA      CharA =      CharA.Create();
    private static readonly CharB      CharB =      CharB.Create();
    private static readonly CharC      CharC =      CharC.Create();
    private static readonly CharD      CharD =      CharD.Create();
    private static readonly CharColon  CharColon =  CharColon.Create();
    private static readonly CharDollar CharDollar = CharDollar.Create();
    private static readonly CharDot    CharDot =    CharDot.Create();
    private static readonly CharHyphen CharHyphen = CharHyphen.Create();
    private static readonly CharForwardSlash CharForwardSlash = CharForwardSlash.Create();
    private static readonly CharPlus   CharPlus =   CharPlus.Create();
    private static readonly CharStar   CharStar =   CharStar.Create();
    private static readonly CharE      CharE =      CharE.Create();
    private static readonly CharN      CharN =      CharN.Create();
    private static readonly CharT      CharT =      CharT.Create();
    
    private static Dictionary<char, ICodabarChar> Dict => new()
    {
        { Char0.Char,      Char0 },
        { Char1.Char,      Char1 },
        { Char2.Char,      Char2 },
        { Char3.Char,      Char3 },
        { Char4.Char,      Char4 },
        { Char5.Char,      Char5 },
        { Char6.Char,      Char6 },
        { Char7.Char,      Char7 },
        { Char8.Char,      Char8 },
        { Char9.Char,      Char9 },
        { CharA.Char,      CharA },
        { CharB.Char,      CharB },
        { CharC.Char,      CharC },
        { CharD.Char,      CharD },
        { CharColon.Char,  CharColon },
        { CharDollar.Char, CharDollar },
        { CharDot.Char,    CharDot },
        { CharHyphen.Char, CharHyphen },
        { CharForwardSlash.Char, CharForwardSlash },
        { CharPlus.Char,   CharPlus },
        { CharStar.Char,   CharStar },
        { CharE.Char,      CharE },
        { CharN.Char,      CharN },
        { CharT.Char,      CharT },
    };

    public static bool IsCodabarChar(char @char) => Dict.ContainsKey(@char);

    public static Option<ICodabarChar> TryGet(char @char)
        => IsCodabarChar(@char) ? Option<ICodabarChar>.Some(Dict[@char]) : Option<ICodabarChar>.None;
}