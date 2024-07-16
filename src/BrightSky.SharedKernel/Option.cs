namespace BrightSky.SharedKernel;

public readonly record struct Option<TValue>
{
    private readonly TValue _value;

    private Option(TValue value) => (IsSome, _value) = (true, value);

    public readonly bool IsSome;
    public bool IsNone => !IsSome;
    
    public TValue Value => IsSome ? _value! : throw new NullReferenceException();

    public static Option<TValue> None => default;
    public static Option<TValue> Some(TValue value) => new(value);

    public static implicit operator Option<TValue>(TValue value) => Some(value);
}

public static class OptionExtensions
{
    public static TResult Match<TValue, TResult>(this Option<TValue> option, Func<TValue, TResult> some, Func<TResult> none)
        => option.IsSome ? some(option.Value) : none();

    public static Option<TResult> Map<TValue, TResult>(this Option<TValue> option, Func<TValue, TResult> map)
        => option.Match(some => map(some), () => Option<TResult>.None);

    public static Option<TResult> Bind<TValue, TResult>(this Option<TValue> option, Func<TValue, Option<TResult>> bind)
        => option.Match(bind, () => Option<TResult>.None);

    public static Option<TValue> Tap<TValue>(this Option<TValue> option, Action<TValue> action)
    {
        if (option.IsSome) action(option.Value);
        return option;
    }

    public static TValue Reduce<TValue>(this Option<TValue> option, TValue @default)
        => option.Match(some => some, () => @default);
}