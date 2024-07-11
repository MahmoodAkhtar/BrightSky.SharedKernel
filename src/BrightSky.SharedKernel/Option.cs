namespace BrightSky.SharedKernel;

public readonly record struct Option<TValue>
{
    private readonly TValue _value;

    private Option(TValue value)
    {
        IsSome = true;
        _value = value;
    }

    public readonly bool IsSome;
    public bool IsNone => !IsSome;
    
    public TValue Value => IsSome ? _value! : throw new NullReferenceException();

    public static Option<TValue> None => default;
    public static Option<TValue> Some(TValue value) => new(value);

    public static implicit operator Option<TValue>(TValue value) => Some(value);
}

public static class OptionExtensions
{
    public static Option<TResult> Map
        <TValue, TResult>(
            this Option<TValue> option,
            Func<TValue, TResult> map)
        => option.IsSome ? Option<TResult>.Some(map(option.Value)) : Option<TResult>.None;

    public static Option<TResult> Bind
        <TValue, TResult>(
            this Option<TValue> option,
            Func<TValue, Option<TResult>> bind)
        => option.IsSome ? bind(option.Value) : Option<TResult>.None;

    public static Option<TValue> Tap
        <TValue>(
            this Option<TValue> option,
            Action<TValue> action)
    {
        if (option.IsSome) action(option.Value);
        return option;
    }
    
    public static TValue Reduce
        <TValue>(
            this Option<TValue> option, TValue @default)
        => option.IsSome ? option.Value : @default;
}