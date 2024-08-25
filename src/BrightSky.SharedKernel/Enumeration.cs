using System.Reflection;

namespace BrightSky.SharedKernel;

public abstract record Enumeration<TEnum, TValue> 
    where TEnum : Enumeration<TEnum, TValue>
    where TValue : notnull
{
    private static readonly Dictionary<TValue, TEnum> _enumerations = GetDerivedEnumerations();

    private static Dictionary<TValue, TEnum> GetDerivedEnumerations()
    {
        var type = typeof(TEnum);
        var enumerations = type
            .GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(pi => pi.DeclaringType == type)
            .Select(pi => (TEnum)pi.GetValue(null)!);

        return enumerations.ToDictionary(x => x.Value, x => x);
    }

    public readonly string Name = string.Empty;
    public readonly TValue Value;

    protected Enumeration(string name, TValue value)
    {
        Name = name;
        Value = value;
    }

    public static Option<TEnum> FromName(string name)
        => _enumerations.Values.SingleOrDefault(x => x.Name == name) ?? Option<TEnum>.None;

    public static Option<TEnum> FromValue(TValue value)
        => _enumerations.TryGetValue(value, out var enumeration) ? enumeration : Option<TEnum>.None;
}