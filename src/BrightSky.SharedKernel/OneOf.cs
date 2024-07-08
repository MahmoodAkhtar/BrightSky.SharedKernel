namespace BrightSky.SharedKernel;

public interface IOneOf 
{
    bool Is<T>();
    T Get<T>();
    bool TryGet<T>(out T value);
}

public record OneOfBase : IOneOf
{
    private readonly object _value;

    protected OneOfBase(object value) => _value= value ?? throw new ArgumentNullException(nameof(value));

    public T Get<T>() => _value is T t ? t : throw new InvalidCastException();
    public bool Is<T>() => _value is T;

    public bool TryGet<T>(out T value)
    {
        if (Is<T>())
        {
            value = Get<T>();
            return true;
        }

        value = default!;
        return false;
    }
}

public record OneOf<T1, T2> : OneOfBase
{
    protected OneOf(T1 value) : base(value!){}
    protected OneOf(T2 value) : base(value!){}

    public static OneOf<T1, T2> Case(T1 value) => new(value!);
    public static OneOf<T1, T2> Case(T2 value) => new(value!);
    
    public static implicit operator OneOf<T1, T2>(T1 value) => Case(value);
    public static implicit operator OneOf<T1, T2>(T2 value) => Case(value);
    
    public static explicit operator T1(OneOf<T1, T2> oneOf) => oneOf.Get<T1>();
    public static explicit operator T2(OneOf<T1, T2> oneOf) => oneOf.Get<T2>();


}

public record OneOf<T1, T2, T3> : OneOfBase
{
    protected OneOf(T1 value) : base(value!) { }
    protected OneOf(T2 value) : base(value!) { }
    protected OneOf(T3 value) : base(value!) { }

    public static OneOf<T1, T2, T3> Case(T1 value) => new(value!);
    public static OneOf<T1, T2, T3> Case(T2 value) => new(value!);
    public static OneOf<T1, T2, T3> Case(T3 value) => new(value!);

    public static implicit operator OneOf<T1, T2, T3>(T1 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3>(T2 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3>(T3 value) => Case(value);

    public static explicit operator T1(OneOf<T1, T2, T3> oneOf) => oneOf.Get<T1>();
    public static explicit operator T2(OneOf<T1, T2, T3> oneOf) => oneOf.Get<T2>();
    public static explicit operator T3(OneOf<T1, T2, T3> oneOf) => oneOf.Get<T3>();
}

public record OneOf<T1, T2, T3, T4> : OneOfBase
{
    protected OneOf(T1 value) : base(value!) { }
    protected OneOf(T2 value) : base(value!) { }
    protected OneOf(T3 value) : base(value!) { }
    protected OneOf(T4 value) : base(value!) { }

    public static OneOf<T1, T2, T3, T4> Case(T1 value) => new(value!);
    public static OneOf<T1, T2, T3, T4> Case(T2 value) => new(value!);
    public static OneOf<T1, T2, T3, T4> Case(T3 value) => new(value!);
    public static OneOf<T1, T2, T3, T4> Case(T4 value) => new(value!);

    public static implicit operator OneOf<T1, T2, T3, T4>(T1 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4>(T2 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4>(T3 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4>(T4 value) => Case(value);

    public static explicit operator T1(OneOf<T1, T2, T3, T4> oneOf) => oneOf.Get<T1>();
    public static explicit operator T2(OneOf<T1, T2, T3, T4> oneOf) => oneOf.Get<T2>();
    public static explicit operator T3(OneOf<T1, T2, T3, T4> oneOf) => oneOf.Get<T3>();
    public static explicit operator T4(OneOf<T1, T2, T3, T4> oneOf) => oneOf.Get<T4>();
}

public record OneOf<T1, T2, T3, T4, T5> : OneOfBase
{
    protected OneOf(T1 value) : base(value!) { }
    protected OneOf(T2 value) : base(value!) { }
    protected OneOf(T3 value) : base(value!) { }
    protected OneOf(T4 value) : base(value!) { }
    protected OneOf(T5 value) : base(value!) { }

    public static OneOf<T1, T2, T3, T4, T5> Case(T1 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5> Case(T2 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5> Case(T3 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5> Case(T4 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5> Case(T5 value) => new(value!);

    public static implicit operator OneOf<T1, T2, T3, T4, T5>(T1 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5>(T2 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5>(T3 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5>(T4 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5>(T5 value) => Case(value);

    public static explicit operator T1(OneOf<T1, T2, T3, T4, T5> oneOf) => oneOf.Get<T1>();
    public static explicit operator T2(OneOf<T1, T2, T3, T4, T5> oneOf) => oneOf.Get<T2>();
    public static explicit operator T3(OneOf<T1, T2, T3, T4, T5> oneOf) => oneOf.Get<T3>();
    public static explicit operator T4(OneOf<T1, T2, T3, T4, T5> oneOf) => oneOf.Get<T4>();
    public static explicit operator T5(OneOf<T1, T2, T3, T4, T5> oneOf) => oneOf.Get<T5>();
}

public record OneOf<T1, T2, T3, T4, T5, T6> : OneOfBase
{
    protected OneOf(T1 value) : base(value!) { }
    protected OneOf(T2 value) : base(value!) { }
    protected OneOf(T3 value) : base(value!) { }
    protected OneOf(T4 value) : base(value!) { }
    protected OneOf(T5 value) : base(value!) { }
    protected OneOf(T6 value) : base(value!) { }

    public static OneOf<T1, T2, T3, T4, T5, T6> Case(T1 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6> Case(T2 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6> Case(T3 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6> Case(T4 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6> Case(T5 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6> Case(T6 value) => new(value!);

    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6>(T1 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6>(T2 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6>(T3 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6>(T4 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6>(T5 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6>(T6 value) => Case(value);

    public static explicit operator T1(OneOf<T1, T2, T3, T4, T5, T6> oneOf) => oneOf.Get<T1>();
    public static explicit operator T2(OneOf<T1, T2, T3, T4, T5, T6> oneOf) => oneOf.Get<T2>();
    public static explicit operator T3(OneOf<T1, T2, T3, T4, T5, T6> oneOf) => oneOf.Get<T3>();
    public static explicit operator T4(OneOf<T1, T2, T3, T4, T5, T6> oneOf) => oneOf.Get<T4>();
    public static explicit operator T5(OneOf<T1, T2, T3, T4, T5, T6> oneOf) => oneOf.Get<T5>();
    public static explicit operator T6(OneOf<T1, T2, T3, T4, T5, T6> oneOf) => oneOf.Get<T6>();
}

public record OneOf<T1, T2, T3, T4, T5, T6, T7> : OneOfBase
{
    protected OneOf(T1 value) : base(value!) { }
    protected OneOf(T2 value) : base(value!) { }
    protected OneOf(T3 value) : base(value!) { }
    protected OneOf(T4 value) : base(value!) { }
    protected OneOf(T5 value) : base(value!) { }
    protected OneOf(T6 value) : base(value!) { }
    protected OneOf(T7 value) : base(value!) { }

    public static OneOf<T1, T2, T3, T4, T5, T6, T7> Case(T1 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7> Case(T2 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7> Case(T3 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7> Case(T4 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7> Case(T5 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7> Case(T6 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7> Case(T7 value) => new(value!);

    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7>(T1 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7>(T2 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7>(T3 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7>(T4 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7>(T5 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7>(T6 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7>(T7 value) => Case(value);

    public static explicit operator T1(OneOf<T1, T2, T3, T4, T5, T6, T7> oneOf) => oneOf.Get<T1>();
    public static explicit operator T2(OneOf<T1, T2, T3, T4, T5, T6, T7> oneOf) => oneOf.Get<T2>();
    public static explicit operator T3(OneOf<T1, T2, T3, T4, T5, T6, T7> oneOf) => oneOf.Get<T3>();
    public static explicit operator T4(OneOf<T1, T2, T3, T4, T5, T6, T7> oneOf) => oneOf.Get<T4>();
    public static explicit operator T5(OneOf<T1, T2, T3, T4, T5, T6, T7> oneOf) => oneOf.Get<T5>();
    public static explicit operator T6(OneOf<T1, T2, T3, T4, T5, T6, T7> oneOf) => oneOf.Get<T6>();
    public static explicit operator T7(OneOf<T1, T2, T3, T4, T5, T6, T7> oneOf) => oneOf.Get<T7>();
}

public record OneOf<T1, T2, T3, T4, T5, T6, T7, T8> : OneOfBase
{
    protected OneOf(T1 value) : base(value!) { }
    protected OneOf(T2 value) : base(value!) { }
    protected OneOf(T3 value) : base(value!) { }
    protected OneOf(T4 value) : base(value!) { }
    protected OneOf(T5 value) : base(value!) { }
    protected OneOf(T6 value) : base(value!) { }
    protected OneOf(T7 value) : base(value!) { }
    protected OneOf(T8 value) : base(value!) { }

    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8> Case(T1 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8> Case(T2 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8> Case(T3 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8> Case(T4 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8> Case(T5 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8> Case(T6 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8> Case(T7 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8> Case(T8 value) => new(value!);

    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8>(T1 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8>(T2 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8>(T3 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8>(T4 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8>(T5 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8>(T6 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8>(T7 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8>(T8 value) => Case(value);

    public static explicit operator T1(OneOf<T1, T2, T3, T4, T5, T6, T7, T8> oneOf) => oneOf.Get<T1>();
    public static explicit operator T2(OneOf<T1, T2, T3, T4, T5, T6, T7, T8> oneOf) => oneOf.Get<T2>();
    public static explicit operator T3(OneOf<T1, T2, T3, T4, T5, T6, T7, T8> oneOf) => oneOf.Get<T3>();
    public static explicit operator T4(OneOf<T1, T2, T3, T4, T5, T6, T7, T8> oneOf) => oneOf.Get<T4>();
    public static explicit operator T5(OneOf<T1, T2, T3, T4, T5, T6, T7, T8> oneOf) => oneOf.Get<T5>();
    public static explicit operator T6(OneOf<T1, T2, T3, T4, T5, T6, T7, T8> oneOf) => oneOf.Get<T6>();
    public static explicit operator T7(OneOf<T1, T2, T3, T4, T5, T6, T7, T8> oneOf) => oneOf.Get<T7>();
    public static explicit operator T8(OneOf<T1, T2, T3, T4, T5, T6, T7, T8> oneOf) => oneOf.Get<T8>();
}

public record OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> : OneOfBase
{
    protected OneOf(T1 value) : base(value!) { }
    protected OneOf(T2 value) : base(value!) { }
    protected OneOf(T3 value) : base(value!) { }
    protected OneOf(T4 value) : base(value!) { }
    protected OneOf(T5 value) : base(value!) { }
    protected OneOf(T6 value) : base(value!) { }
    protected OneOf(T7 value) : base(value!) { }
    protected OneOf(T8 value) : base(value!) { }
    protected OneOf(T9 value) : base(value!) { }

    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> Case(T1 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> Case(T2 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> Case(T3 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> Case(T4 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> Case(T5 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> Case(T6 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> Case(T7 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> Case(T8 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> Case(T9 value) => new(value!);

    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T2 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T3 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T4 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T5 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T6 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T8 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T9 value) => Case(value);

    public static explicit operator T1(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> oneOf) => oneOf.Get<T1>();
    public static explicit operator T2(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> oneOf) => oneOf.Get<T2>();
    public static explicit operator T3(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> oneOf) => oneOf.Get<T3>();
    public static explicit operator T4(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> oneOf) => oneOf.Get<T4>();
    public static explicit operator T5(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> oneOf) => oneOf.Get<T5>();
    public static explicit operator T6(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> oneOf) => oneOf.Get<T6>();
    public static explicit operator T7(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> oneOf) => oneOf.Get<T7>();
    public static explicit operator T8(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> oneOf) => oneOf.Get<T8>();
    public static explicit operator T9(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> oneOf) => oneOf.Get<T9>();
}

public record OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : OneOfBase
{
    protected OneOf(T1 value) : base(value!) { }
    protected OneOf(T2 value) : base(value!) { }
    protected OneOf(T3 value) : base(value!) { }
    protected OneOf(T4 value) : base(value!) { }
    protected OneOf(T5 value) : base(value!) { }
    protected OneOf(T6 value) : base(value!) { }
    protected OneOf(T7 value) : base(value!) { }
    protected OneOf(T8 value) : base(value!) { }
    protected OneOf(T9 value) : base(value!) { }
    protected OneOf(T10 value) : base(value!) { }

    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Case(T1 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Case(T2 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Case(T3 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Case(T4 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Case(T5 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Case(T6 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Case(T7 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Case(T8 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Case(T9 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Case(T10 value) => new(value!);

    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T2 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T3 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T4 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T5 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T6 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T7 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T8 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T9 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T10 value) => Case(value);

    public static explicit operator T1(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> oneOf) => oneOf.Get<T1>();
    public static explicit operator T2(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> oneOf) => oneOf.Get<T2>();
    public static explicit operator T3(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> oneOf) => oneOf.Get<T3>();
    public static explicit operator T4(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> oneOf) => oneOf.Get<T4>();
    public static explicit operator T5(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> oneOf) => oneOf.Get<T5>();
    public static explicit operator T6(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> oneOf) => oneOf.Get<T6>();
    public static explicit operator T7(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> oneOf) => oneOf.Get<T7>();
    public static explicit operator T8(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> oneOf) => oneOf.Get<T8>();
    public static explicit operator T9(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> oneOf) => oneOf.Get<T9>();
    public static explicit operator T10(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> oneOf) => oneOf.Get<T10>();
}

public record OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : OneOfBase
{
    protected OneOf(T1 value) : base(value!) { }
    protected OneOf(T2 value) : base(value!) { }
    protected OneOf(T3 value) : base(value!) { }
    protected OneOf(T4 value) : base(value!) { }
    protected OneOf(T5 value) : base(value!) { }
    protected OneOf(T6 value) : base(value!) { }
    protected OneOf(T7 value) : base(value!) { }
    protected OneOf(T8 value) : base(value!) { }
    protected OneOf(T9 value) : base(value!) { }
    protected OneOf(T10 value) : base(value!) { }
    protected OneOf(T11 value) : base(value!) { }

    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Case(T1 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Case(T2 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Case(T3 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Case(T4 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Case(T5 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Case(T6 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Case(T7 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Case(T8 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Case(T9 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Case(T10 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Case(T11 value) => new(value!);

    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T2 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T3 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T4 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T5 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T6 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T7 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T8 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T9 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T10 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T11 value) => Case(value);

    public static explicit operator T1(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> oneOf) => oneOf.Get<T1>();
    public static explicit operator T2(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> oneOf) => oneOf.Get<T2>();
    public static explicit operator T3(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> oneOf) => oneOf.Get<T3>();
    public static explicit operator T4(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> oneOf) => oneOf.Get<T4>();
    public static explicit operator T5(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> oneOf) => oneOf.Get<T5>();
    public static explicit operator T6(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> oneOf) => oneOf.Get<T6>();
    public static explicit operator T7(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> oneOf) => oneOf.Get<T7>();
    public static explicit operator T8(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> oneOf) => oneOf.Get<T8>();
    public static explicit operator T9(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> oneOf) => oneOf.Get<T9>();
    public static explicit operator T10(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> oneOf) => oneOf.Get<T10>();
    public static explicit operator T11(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> oneOf) => oneOf.Get<T11>();
}

public record OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : OneOfBase
{
    protected OneOf(T1 value) : base(value!) { }
    protected OneOf(T2 value) : base(value!) { }
    protected OneOf(T3 value) : base(value!) { }
    protected OneOf(T4 value) : base(value!) { }
    protected OneOf(T5 value) : base(value!) { }
    protected OneOf(T6 value) : base(value!) { }
    protected OneOf(T7 value) : base(value!) { }
    protected OneOf(T8 value) : base(value!) { }
    protected OneOf(T9 value) : base(value!) { }
    protected OneOf(T10 value) : base(value!) { }
    protected OneOf(T11 value) : base(value!) { }
    protected OneOf(T12 value) : base(value!) { }

    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Case(T1 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Case(T2 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Case(T3 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Case(T4 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Case(T5 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Case(T6 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Case(T7 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Case(T8 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Case(T9 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Case(T10 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Case(T11 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Case(T12 value) => new(value!);

    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T2 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T3 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T4 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T5 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T6 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T7 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T8 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T9 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T10 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T11 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T12 value) => Case(value);

    public static explicit operator T1(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> oneOf) => oneOf.Get<T1>();
    public static explicit operator T2(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> oneOf) => oneOf.Get<T2>();
    public static explicit operator T3(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> oneOf) => oneOf.Get<T3>();
    public static explicit operator T4(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> oneOf) => oneOf.Get<T4>();
    public static explicit operator T5(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> oneOf) => oneOf.Get<T5>();
    public static explicit operator T6(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> oneOf) => oneOf.Get<T6>();
    public static explicit operator T7(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> oneOf) => oneOf.Get<T7>();
    public static explicit operator T8(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> oneOf) => oneOf.Get<T8>();
    public static explicit operator T9(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> oneOf) => oneOf.Get<T9>();
    public static explicit operator T10(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> oneOf) => oneOf.Get<T10>();
    public static explicit operator T11(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> oneOf) => oneOf.Get<T11>();
    public static explicit operator T12(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> oneOf) => oneOf.Get<T12>();
}

public record OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : OneOfBase
{
    protected OneOf(T1 value) : base(value!) { }
    protected OneOf(T2 value) : base(value!) { }
    protected OneOf(T3 value) : base(value!) { }
    protected OneOf(T4 value) : base(value!) { }
    protected OneOf(T5 value) : base(value!) { }
    protected OneOf(T6 value) : base(value!) { }
    protected OneOf(T7 value) : base(value!) { }
    protected OneOf(T8 value) : base(value!) { }
    protected OneOf(T9 value) : base(value!) { }
    protected OneOf(T10 value) : base(value!) { }
    protected OneOf(T11 value) : base(value!) { }
    protected OneOf(T12 value) : base(value!) { }
    protected OneOf(T13 value) : base(value!) { }

    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Case(T1 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Case(T2 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Case(T3 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Case(T4 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Case(T5 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Case(T6 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Case(T7 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Case(T8 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Case(T9 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Case(T10 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Case(T11 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Case(T12 value) => new(value!);
    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Case(T13 value) => new(value!);

    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T2 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T3 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T4 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T5 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T6 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T7 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T8 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T9 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T10 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T11 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T12 value) => Case(value);
    public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T13 value) => Case(value);

    public static explicit operator T1(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> oneOf) => oneOf.Get<T1>();
    public static explicit operator T2(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> oneOf) => oneOf.Get<T2>();
    public static explicit operator T3(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> oneOf) => oneOf.Get<T3>();
    public static explicit operator T4(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> oneOf) => oneOf.Get<T4>();
    public static explicit operator T5(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> oneOf) => oneOf.Get<T5>();
    public static explicit operator T6(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> oneOf) => oneOf.Get<T6>();
    public static explicit operator T7(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> oneOf) => oneOf.Get<T7>();
    public static explicit operator T8(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> oneOf) => oneOf.Get<T8>();
    public static explicit operator T9(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> oneOf) => oneOf.Get<T9>();
    public static explicit operator T10(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> oneOf) => oneOf.Get<T10>();
    public static explicit operator T11(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> oneOf) => oneOf.Get<T11>();
    public static explicit operator T12(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> oneOf) => oneOf.Get<T12>();
    public static explicit operator T13(OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> oneOf) => oneOf.Get<T13>();
}

public static class MatchOneOfExtensions
{
    public static TResult Match
        <T1, T2, TResult>(
        this OneOf<T1, T2> oneOf,
        Func<T1, TResult> caseOne,
        Func<T2, TResult> caseTwo)
    {
        var dict = new Dictionary<Func<bool>, Func<TResult>>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) }
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static TResult Match
        <T1, T2, T3, TResult>(
            this OneOf<T1, T2, T3> oneOf,
            Func<T1, TResult> caseOne,
            Func<T2, TResult> caseTwo,
            Func<T3, TResult> caseThree)
    {
        var dict = new Dictionary<Func<bool>, Func<TResult>>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) }
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static TResult Match
        <T1, T2, T3, T4, TResult>(
            this OneOf<T1, T2, T3, T4> oneOf,
            Func<T1, TResult> caseOne,
            Func<T2, TResult> caseTwo,
            Func<T3, TResult> caseThree,
            Func<T4, TResult> caseFour)
    {
        var dict = new Dictionary<Func<bool>, Func<TResult>>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static TResult Match
        <T1, T2, T3, T4, T5, TResult>(
            this OneOf<T1, T2, T3, T4, T5> oneOf,
            Func<T1, TResult> caseOne,
            Func<T2, TResult> caseTwo,
            Func<T3, TResult> caseThree,
            Func<T4, TResult> caseFour,
            Func<T5, TResult> caseFive)
    {
        var dict = new Dictionary<Func<bool>, Func<TResult>>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
            { oneOf.Is<T5>, () => caseFive(oneOf.Get<T5>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static TResult Match
        <T1, T2, T3, T4, T5, T6, TResult>(
            this OneOf<T1, T2, T3, T4, T5, T6> oneOf,
            Func<T1, TResult> caseOne,
            Func<T2, TResult> caseTwo,
            Func<T3, TResult> caseThree,
            Func<T4, TResult> caseFour,
            Func<T5, TResult> caseFive,
            Func<T6, TResult> caseSix)
            {
        var dict = new Dictionary<Func<bool>, Func<TResult>>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
            { oneOf.Is<T5>, () => caseFive(oneOf.Get<T5>()) },
            { oneOf.Is<T6>, () => caseSix(oneOf.Get<T6>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static TResult Match
        <T1, T2, T3, T4, T5, T6, T7, TResult>(
            this OneOf<T1, T2, T3, T4, T5, T6, T7> oneOf,
            Func<T1, TResult> caseOne,
            Func<T2, TResult> caseTwo,
            Func<T3, TResult> caseThree,
            Func<T4, TResult> caseFour,
            Func<T5, TResult> caseFive,
            Func<T6, TResult> caseSix,
            Func<T7, TResult> caseSeven)
    {
        var dict = new Dictionary<Func<bool>, Func<TResult>>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
            { oneOf.Is<T5>, () => caseFive(oneOf.Get<T5>()) },
            { oneOf.Is<T6>, () => caseSix(oneOf.Get<T6>()) },
            { oneOf.Is<T7>, () => caseSeven(oneOf.Get<T7>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static TResult Match
        <T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            this OneOf<T1, T2, T3, T4, T5, T6, T7, T8> oneOf,
            Func<T1, TResult> caseOne,
            Func<T2, TResult> caseTwo,
            Func<T3, TResult> caseThree,
            Func<T4, TResult> caseFour,
            Func<T5, TResult> caseFive,
            Func<T6, TResult> caseSix,
            Func<T7, TResult> caseSeven,
            Func<T8, TResult> caseEight)
    {
        var dict = new Dictionary<Func<bool>, Func<TResult>>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
            { oneOf.Is<T5>, () => caseFive(oneOf.Get<T5>()) },
            { oneOf.Is<T6>, () => caseSix(oneOf.Get<T6>()) },
            { oneOf.Is<T7>, () => caseSeven(oneOf.Get<T7>()) },
            { oneOf.Is<T8>, () => caseEight(oneOf.Get<T8>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static TResult Match
        <T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            this OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> oneOf,
            Func<T1, TResult> caseOne,
            Func<T2, TResult> caseTwo,
            Func<T3, TResult> caseThree,
            Func<T4, TResult> caseFour,
            Func<T5, TResult> caseFive,
            Func<T6, TResult> caseSix,
            Func<T7, TResult> caseSeven,
            Func<T8, TResult> caseEight,
            Func<T9, TResult> caseNine)
    {
        var dict = new Dictionary<Func<bool>, Func<TResult>>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
            { oneOf.Is<T5>, () => caseFive(oneOf.Get<T5>()) },
            { oneOf.Is<T6>, () => caseSix(oneOf.Get<T6>()) },
            { oneOf.Is<T7>, () => caseSeven(oneOf.Get<T7>()) },
            { oneOf.Is<T8>, () => caseEight(oneOf.Get<T8>()) },
            { oneOf.Is<T9>, () => caseNine(oneOf.Get<T9>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static TResult Match
        <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            this OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> oneOf,
            Func<T1, TResult> caseOne,
            Func<T2, TResult> caseTwo,
            Func<T3, TResult> caseThree,
            Func<T4, TResult> caseFour,
            Func<T5, TResult> caseFive,
            Func<T6, TResult> caseSix,
            Func<T7, TResult> caseSeven,
            Func<T8, TResult> caseEight,
            Func<T9, TResult> caseNine,
            Func<T10, TResult> caseTen)
    {
        var dict = new Dictionary<Func<bool>, Func<TResult>>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
            { oneOf.Is<T5>, () => caseFive(oneOf.Get<T5>()) },
            { oneOf.Is<T6>, () => caseSix(oneOf.Get<T6>()) },
            { oneOf.Is<T7>, () => caseSeven(oneOf.Get<T7>()) },
            { oneOf.Is<T8>, () => caseEight(oneOf.Get<T8>()) },
            { oneOf.Is<T9>, () => caseNine(oneOf.Get<T9>()) },
            { oneOf.Is<T10>, () => caseTen(oneOf.Get<T10>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static TResult Match
        <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            this OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> oneOf,
            Func<T1, TResult> caseOne,
            Func<T2, TResult> caseTwo,
            Func<T3, TResult> caseThree,
            Func<T4, TResult> caseFour,
            Func<T5, TResult> caseFive,
            Func<T6, TResult> caseSix,
            Func<T7, TResult> caseSeven,
            Func<T8, TResult> caseEight,
            Func<T9, TResult> caseNine,
            Func<T10, TResult> caseTen,
            Func<T11, TResult> caseEleven)
    {
        var dict = new Dictionary<Func<bool>, Func<TResult>>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
            { oneOf.Is<T5>, () => caseFive(oneOf.Get<T5>()) },
            { oneOf.Is<T6>, () => caseSix(oneOf.Get<T6>()) },
            { oneOf.Is<T7>, () => caseSeven(oneOf.Get<T7>()) },
            { oneOf.Is<T8>, () => caseEight(oneOf.Get<T8>()) },
            { oneOf.Is<T9>, () => caseNine(oneOf.Get<T9>()) },
            { oneOf.Is<T10>, () => caseTen(oneOf.Get<T10>()) },
            { oneOf.Is<T11>, () => caseEleven(oneOf.Get<T11>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static TResult Match
        <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            this OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> oneOf,
            Func<T1, TResult> caseOne,
            Func<T2, TResult> caseTwo,
            Func<T3, TResult> caseThree,
            Func<T4, TResult> caseFour,
            Func<T5, TResult> caseFive,
            Func<T6, TResult> caseSix,
            Func<T7, TResult> caseSeven,
            Func<T8, TResult> caseEight,
            Func<T9, TResult> caseNine,
            Func<T10, TResult> caseTen,
            Func<T11, TResult> caseEleven,
            Func<T12, TResult> caseTwelve)
    {
        var dict = new Dictionary<Func<bool>, Func<TResult>>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
            { oneOf.Is<T5>, () => caseFive(oneOf.Get<T5>()) },
            { oneOf.Is<T6>, () => caseSix(oneOf.Get<T6>()) },
            { oneOf.Is<T7>, () => caseSeven(oneOf.Get<T7>()) },
            { oneOf.Is<T8>, () => caseEight(oneOf.Get<T8>()) },
            { oneOf.Is<T9>, () => caseNine(oneOf.Get<T9>()) },
            { oneOf.Is<T10>, () => caseTen(oneOf.Get<T10>()) },
            { oneOf.Is<T11>, () => caseEleven(oneOf.Get<T11>()) },
            { oneOf.Is<T12>, () => caseTwelve(oneOf.Get<T12>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static TResult Match
        <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
            this OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> oneOf,
            Func<T1, TResult> caseOne,
            Func<T2, TResult> caseTwo,
            Func<T3, TResult> caseThree,
            Func<T4, TResult> caseFour,
            Func<T5, TResult> caseFive,
            Func<T6, TResult> caseSix,
            Func<T7, TResult> caseSeven,
            Func<T8, TResult> caseEight,
            Func<T9, TResult> caseNine,
            Func<T10, TResult> caseTen,
            Func<T11, TResult> caseEleven,
            Func<T12, TResult> caseTwelve,
            Func<T13, TResult> caseThirteen)
    {
        var dict = new Dictionary<Func<bool>, Func<TResult>>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
            { oneOf.Is<T5>, () => caseFive(oneOf.Get<T5>()) },
            { oneOf.Is<T6>, () => caseSix(oneOf.Get<T6>()) },
            { oneOf.Is<T7>, () => caseSeven(oneOf.Get<T7>()) },
            { oneOf.Is<T8>, () => caseEight(oneOf.Get<T8>()) },
            { oneOf.Is<T9>, () => caseNine(oneOf.Get<T9>()) },
            { oneOf.Is<T10>, () => caseTen(oneOf.Get<T10>()) },
            { oneOf.Is<T11>, () => caseEleven(oneOf.Get<T11>()) },
            { oneOf.Is<T12>, () => caseTwelve(oneOf.Get<T12>()) },
            { oneOf.Is<T13>, () => caseThirteen(oneOf.Get<T13>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }
}

public static class TapOneOfExtensions
{
    public static OneOf<T1, T2> Tap
        <T1, T2>(
            this OneOf<T1, T2> oneOf,
            Action<T1> caseOne,
            Action<T2> caseTwo)
    {
        var dict = new Dictionary<Func<bool>, Action>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) }
        };

        dict.First(x => x.Key()).Value();
        return oneOf;
    }

    public static OneOf<T1, T2, T3> Tap
        <T1, T2, T3>(
            this OneOf<T1, T2, T3> oneOf,
            Action<T1> caseOne,
            Action<T2> caseTwo,
            Action<T3> caseThree)
    {
        var dict = new Dictionary<Func<bool>, Action>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) }
        };

        dict.First(x => x.Key()).Value();
        return oneOf;
    }

    public static OneOf<T1, T2, T3, T4> Tap
        <T1, T2, T3, T4>(
            this OneOf<T1, T2, T3, T4> oneOf,
            Action<T1> caseOne,
            Action<T2> caseTwo,
            Action<T3> caseThree,
            Action<T4> caseFour)
    {
        var dict = new Dictionary<Func<bool>, Action>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
        };

        dict.First(x => x.Key()).Value();
        return oneOf;
    }
    public static OneOf<T1, T2, T3, T4, T5> Tap
        <T1, T2, T3, T4, T5>(
            this OneOf<T1, T2, T3, T4, T5> oneOf,
            Action<T1> caseOne,
            Action<T2> caseTwo,
            Action<T3> caseThree,
            Action<T4> caseFour,
            Action<T5> caseFive)
    {
        var dict = new Dictionary<Func<bool>, Action>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
            { oneOf.Is<T5>, () => caseFive(oneOf.Get<T5>()) },
        };

        dict.First(x => x.Key()).Value();
        return oneOf;
    }

    public static OneOf<T1, T2, T3, T4, T5, T6> Tap
        <T1, T2, T3, T4, T5, T6>(
            this OneOf<T1, T2, T3, T4, T5, T6> oneOf,
            Action<T1> caseOne,
            Action<T2> caseTwo,
            Action<T3> caseThree,
            Action<T4> caseFour,
            Action<T5> caseFive,
            Action<T6> caseSix)
    {
        var dict = new Dictionary<Func<bool>, Action>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
            { oneOf.Is<T5>, () => caseFive(oneOf.Get<T5>()) },
            { oneOf.Is<T6>, () => caseSix(oneOf.Get<T6>()) },
        };

        dict.First(x => x.Key()).Value();
        return oneOf;
    }

    public static OneOf<T1, T2, T3, T4, T5, T6, T7> Tap
        <T1, T2, T3, T4, T5, T6, T7>(
            this OneOf<T1, T2, T3, T4, T5, T6, T7> oneOf,
            Action<T1> caseOne,
            Action<T2> caseTwo,
            Action<T3> caseThree,
            Action<T4> caseFour,
            Action<T5> caseFive,
            Action<T6> caseSix,
            Action<T7> caseSeven)
    {
        var dict = new Dictionary<Func<bool>, Action>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
            { oneOf.Is<T5>, () => caseFive(oneOf.Get<T5>()) },
            { oneOf.Is<T6>, () => caseSix(oneOf.Get<T6>()) },
            { oneOf.Is<T7>, () => caseSeven(oneOf.Get<T7>()) },
        };

        dict.First(x => x.Key()).Value();
        return oneOf;
    }

    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8> Tap
        <T1, T2, T3, T4, T5, T6, T7, T8>(
            this OneOf<T1, T2, T3, T4, T5, T6, T7, T8> oneOf,
            Action<T1> caseOne,
            Action<T2> caseTwo,
            Action<T3> caseThree,
            Action<T4> caseFour,
            Action<T5> caseFive,
            Action<T6> caseSix,
            Action<T7> caseSeven,
            Action<T8> caseEight)
    {
        var dict = new Dictionary<Func<bool>, Action>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
            { oneOf.Is<T5>, () => caseFive(oneOf.Get<T5>()) },
            { oneOf.Is<T6>, () => caseSix(oneOf.Get<T6>()) },
            { oneOf.Is<T7>, () => caseSeven(oneOf.Get<T7>()) },
            { oneOf.Is<T8>, () => caseEight(oneOf.Get<T8>()) },
        };

        dict.First(x => x.Key()).Value();
        return oneOf;
    }

    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> Tap
        <T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            this OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9> oneOf,
            Action<T1> caseOne,
            Action<T2> caseTwo,
            Action<T3> caseThree,
            Action<T4> caseFour,
            Action<T5> caseFive,
            Action<T6> caseSix,
            Action<T7> caseSeven,
            Action<T8> caseEight,
            Action<T9> caseNine)
    {
        var dict = new Dictionary<Func<bool>, Action>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
            { oneOf.Is<T5>, () => caseFive(oneOf.Get<T5>()) },
            { oneOf.Is<T6>, () => caseSix(oneOf.Get<T6>()) },
            { oneOf.Is<T7>, () => caseSeven(oneOf.Get<T7>()) },
            { oneOf.Is<T8>, () => caseEight(oneOf.Get<T8>()) },
            { oneOf.Is<T9>, () => caseNine(oneOf.Get<T9>()) },
        };

        dict.First(x => x.Key()).Value();
        return oneOf;
    }

    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Tap
        <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            this OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> oneOf,
            Action<T1> caseOne,
            Action<T2> caseTwo,
            Action<T3> caseThree,
            Action<T4> caseFour,
            Action<T5> caseFive,
            Action<T6> caseSix,
            Action<T7> caseSeven,
            Action<T8> caseEight,
            Action<T9> caseNine,
            Action<T10> caseTen)
    {
        var dict = new Dictionary<Func<bool>, Action>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
            { oneOf.Is<T5>, () => caseFive(oneOf.Get<T5>()) },
            { oneOf.Is<T6>, () => caseSix(oneOf.Get<T6>()) },
            { oneOf.Is<T7>, () => caseSeven(oneOf.Get<T7>()) },
            { oneOf.Is<T8>, () => caseEight(oneOf.Get<T8>()) },
            { oneOf.Is<T9>, () => caseNine(oneOf.Get<T9>()) },
            { oneOf.Is<T10>, () => caseTen(oneOf.Get<T10>()) },
        };

        dict.First(x => x.Key()).Value();
        return oneOf;
    }

    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Tap
        <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            this OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> oneOf,
            Action<T1> caseOne,
            Action<T2> caseTwo,
            Action<T3> caseThree,
            Action<T4> caseFour,
            Action<T5> caseFive,
            Action<T6> caseSix,
            Action<T7> caseSeven,
            Action<T8> caseEight,
            Action<T9> caseNine,
            Action<T10> caseTen,
            Action<T11> caseEleven)
    {
        var dict = new Dictionary<Func<bool>, Action>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
            { oneOf.Is<T5>, () => caseFive(oneOf.Get<T5>()) },
            { oneOf.Is<T6>, () => caseSix(oneOf.Get<T6>()) },
            { oneOf.Is<T7>, () => caseSeven(oneOf.Get<T7>()) },
            { oneOf.Is<T8>, () => caseEight(oneOf.Get<T8>()) },
            { oneOf.Is<T9>, () => caseNine(oneOf.Get<T9>()) },
            { oneOf.Is<T10>, () => caseTen(oneOf.Get<T10>()) },
            { oneOf.Is<T11>, () => caseEleven(oneOf.Get<T11>()) },
        };

        dict.First(x => x.Key()).Value();
        return oneOf;
    }

    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Tap
        <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            this OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> oneOf,
            Action<T1> caseOne,
            Action<T2> caseTwo,
            Action<T3> caseThree,
            Action<T4> caseFour,
            Action<T5> caseFive,
            Action<T6> caseSix,
            Action<T7> caseSeven,
            Action<T8> caseEight,
            Action<T9> caseNine,
            Action<T10> caseTen,
            Action<T11> caseEleven,
            Action<T12> caseTwelve)
    {
        var dict = new Dictionary<Func<bool>, Action>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
            { oneOf.Is<T5>, () => caseFive(oneOf.Get<T5>()) },
            { oneOf.Is<T6>, () => caseSix(oneOf.Get<T6>()) },
            { oneOf.Is<T7>, () => caseSeven(oneOf.Get<T7>()) },
            { oneOf.Is<T8>, () => caseEight(oneOf.Get<T8>()) },
            { oneOf.Is<T9>, () => caseNine(oneOf.Get<T9>()) },
            { oneOf.Is<T10>, () => caseTen(oneOf.Get<T10>()) },
            { oneOf.Is<T11>, () => caseEleven(oneOf.Get<T11>()) },
            { oneOf.Is<T12>, () => caseTwelve(oneOf.Get<T12>()) },
        };

        dict.First(x => x.Key()).Value();
        return oneOf;
    }

    public static OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Tap
        <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            this OneOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> oneOf,
            Action<T1> caseOne,
            Action<T2> caseTwo,
            Action<T3> caseThree,
            Action<T4> caseFour,
            Action<T5> caseFive,
            Action<T6> caseSix,
            Action<T7> caseSeven,
            Action<T8> caseEight,
            Action<T9> caseNine,
            Action<T10> caseTen,
            Action<T11> caseEleven,
            Action<T12> caseTwelve,
            Action<T13> caseThirteen)
    {
        var dict = new Dictionary<Func<bool>, Action>
        {
            { oneOf.Is<T1>, () => caseOne(oneOf.Get<T1>()) },
            { oneOf.Is<T2>, () => caseTwo(oneOf.Get<T2>()) },
            { oneOf.Is<T3>, () => caseThree(oneOf.Get<T3>()) },
            { oneOf.Is<T4>, () => caseFour(oneOf.Get<T4>()) },
            { oneOf.Is<T5>, () => caseFive(oneOf.Get<T5>()) },
            { oneOf.Is<T6>, () => caseSix(oneOf.Get<T6>()) },
            { oneOf.Is<T7>, () => caseSeven(oneOf.Get<T7>()) },
            { oneOf.Is<T8>, () => caseEight(oneOf.Get<T8>()) },
            { oneOf.Is<T9>, () => caseNine(oneOf.Get<T9>()) },
            { oneOf.Is<T10>, () => caseTen(oneOf.Get<T10>()) },
            { oneOf.Is<T11>, () => caseEleven(oneOf.Get<T11>()) },
            { oneOf.Is<T12>, () => caseTwelve(oneOf.Get<T12>()) },
            { oneOf.Is<T13>, () => caseThirteen(oneOf.Get<T13>()) },
        };

        dict.First(x => x.Key()).Value();
        return oneOf;
    }

}

public static class MapOneOfExtensions
{
    public static OneOf<T1Out, T2Out> Map
        <T1In, T2In, T1Out, T2Out>(
        this OneOf<T1In, T2In> oneOf,
        Func<T1In, T1Out> caseOne,
        Func<T2In, T2Out> caseTwo)
    {
        if (oneOf.Is<T1In>()) return caseOne(oneOf.Get<T1In>());
        if (oneOf.Is<T2In>()) return caseTwo(oneOf.Get<T2In>());
        throw new InvalidOperationException();
    }

    public static OneOf<T1Out, T2Out, T3Out> Map
        <T1In, T2In, T3In, T1Out, T2Out, T3Out>(
        this OneOf<T1In, T2In, T3In> oneOf,
        Func<T1In, T1Out> caseOne,
        Func<T2In, T2Out> caseTwo,
        Func<T3In, T3Out> caseThree)
    {
        if (oneOf.Is<T1In>()) return caseOne(oneOf.Get<T1In>());
        if (oneOf.Is<T2In>()) return caseTwo(oneOf.Get<T2In>());
        if (oneOf.Is<T3In>()) return caseThree(oneOf.Get<T3In>());
        throw new InvalidOperationException();
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out> Map
        <T1In, T2In, T3In, T4In, T1Out, T2Out, T3Out, T4Out>(
            this OneOf<T1In, T2In, T3In, T4In> oneOf,
            Func<T1In, T1Out> caseOne,
            Func<T2In, T2Out> caseTwo,
            Func<T3In, T3Out> caseThree,
            Func<T4In, T4Out> caseFour)
    {
        if (oneOf.Is<T1In>()) return caseOne(oneOf.Get<T1In>());
        if (oneOf.Is<T2In>()) return caseTwo(oneOf.Get<T2In>());
        if (oneOf.Is<T3In>()) return caseThree(oneOf.Get<T3In>());
        if (oneOf.Is<T4In>()) return caseFour(oneOf.Get<T4In>());
        throw new InvalidOperationException();
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out, T5Out> Map
        <T1In, T2In, T3In, T4In, T5In, T1Out, T2Out, T3Out, T4Out, T5Out>(
            this OneOf<T1In, T2In, T3In, T4In, T5In> oneOf,
            Func<T1In, T1Out> caseOne,
            Func<T2In, T2Out> caseTwo,
            Func<T3In, T3Out> caseThree,
            Func<T4In, T4Out> caseFour,
            Func<T5In, T5Out> caseFive)
    {
        if (oneOf.Is<T1In>()) return caseOne(oneOf.Get<T1In>());
        if (oneOf.Is<T2In>()) return caseTwo(oneOf.Get<T2In>());
        if (oneOf.Is<T3In>()) return caseThree(oneOf.Get<T3In>());
        if (oneOf.Is<T4In>()) return caseFour(oneOf.Get<T4In>());
        if (oneOf.Is<T5In>()) return caseFive(oneOf.Get<T5In>());
        throw new InvalidOperationException();
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out> Map
        <T1In, T2In, T3In, T4In, T5In, T6In, T1Out, T2Out, T3Out, T4Out, T5Out, T6Out>(
            this OneOf<T1In, T2In, T3In, T4In, T5In, T6In> oneOf,
            Func<T1In, T1Out> caseOne,
            Func<T2In, T2Out> caseTwo,
            Func<T3In, T3Out> caseThree,
            Func<T4In, T4Out> caseFour,
            Func<T5In, T5Out> caseFive,
            Func<T6In, T6Out> caseSix)
    {
        if (oneOf.Is<T1In>()) return caseOne(oneOf.Get<T1In>());
        if (oneOf.Is<T2In>()) return caseTwo(oneOf.Get<T2In>());
        if (oneOf.Is<T3In>()) return caseThree(oneOf.Get<T3In>());
        if (oneOf.Is<T4In>()) return caseFour(oneOf.Get<T4In>());
        if (oneOf.Is<T5In>()) return caseFive(oneOf.Get<T5In>());
        if (oneOf.Is<T6In>()) return caseSix(oneOf.Get<T6In>());
        throw new InvalidOperationException();
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out> Map
        <T1In, T2In, T3In, T4In, T5In, T6In, T7In, T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out>(
            this OneOf<T1In, T2In, T3In, T4In, T5In, T6In, T7In> oneOf,
            Func<T1In, T1Out> caseOne,
            Func<T2In, T2Out> caseTwo,
            Func<T3In, T3Out> caseThree,
            Func<T4In, T4Out> caseFour,
            Func<T5In, T5Out> caseFive,
            Func<T6In, T6Out> caseSix,
            Func<T7In, T7Out> caseSeven)
    {
        if (oneOf.Is<T1In>()) return caseOne(oneOf.Get<T1In>());
        if (oneOf.Is<T2In>()) return caseTwo(oneOf.Get<T2In>());
        if (oneOf.Is<T3In>()) return caseThree(oneOf.Get<T3In>());
        if (oneOf.Is<T4In>()) return caseFour(oneOf.Get<T4In>());
        if (oneOf.Is<T5In>()) return caseFive(oneOf.Get<T5In>());
        if (oneOf.Is<T6In>()) return caseSix(oneOf.Get<T6In>());
        if (oneOf.Is<T7In>()) return caseSeven(oneOf.Get<T7In>());
        throw new InvalidOperationException();
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out> Map
        <T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out>(
            this OneOf<T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In> oneOf,
            Func<T1In, T1Out> caseOne,
            Func<T2In, T2Out> caseTwo,
            Func<T3In, T3Out> caseThree,
            Func<T4In, T4Out> caseFour,
            Func<T5In, T5Out> caseFive,
            Func<T6In, T6Out> caseSix,
            Func<T7In, T7Out> caseSeven,
            Func<T8In, T8Out> caseEight)
    {
        if (oneOf.Is<T1In>()) return caseOne(oneOf.Get<T1In>());
        if (oneOf.Is<T2In>()) return caseTwo(oneOf.Get<T2In>());
        if (oneOf.Is<T3In>()) return caseThree(oneOf.Get<T3In>());
        if (oneOf.Is<T4In>()) return caseFour(oneOf.Get<T4In>());
        if (oneOf.Is<T5In>()) return caseFive(oneOf.Get<T5In>());
        if (oneOf.Is<T6In>()) return caseSix(oneOf.Get<T6In>());
        if (oneOf.Is<T7In>()) return caseSeven(oneOf.Get<T7In>());
        if (oneOf.Is<T8In>()) return caseEight(oneOf.Get<T8In>());
        throw new InvalidOperationException();
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out> Map
        <T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In, T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out>(
            this OneOf<T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In> oneOf,
            Func<T1In, T1Out> caseOne,
            Func<T2In, T2Out> caseTwo,
            Func<T3In, T3Out> caseThree,
            Func<T4In, T4Out> caseFour,
            Func<T5In, T5Out> caseFive,
            Func<T6In, T6Out> caseSix,
            Func<T7In, T7Out> caseSeven,
            Func<T8In, T8Out> caseEight,
            Func<T9In, T9Out> caseNine)
    {
        if (oneOf.Is<T1In>()) return caseOne(oneOf.Get<T1In>());
        if (oneOf.Is<T2In>()) return caseTwo(oneOf.Get<T2In>());
        if (oneOf.Is<T3In>()) return caseThree(oneOf.Get<T3In>());
        if (oneOf.Is<T4In>()) return caseFour(oneOf.Get<T4In>());
        if (oneOf.Is<T5In>()) return caseFive(oneOf.Get<T5In>());
        if (oneOf.Is<T6In>()) return caseSix(oneOf.Get<T6In>());
        if (oneOf.Is<T7In>()) return caseSeven(oneOf.Get<T7In>());
        if (oneOf.Is<T8In>()) return caseEight(oneOf.Get<T8In>());
        if (oneOf.Is<T9In>()) return caseNine(oneOf.Get<T9In>());
        throw new InvalidOperationException();
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out> Map
        <T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In, T10In, T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out>(
            this OneOf<T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In, T10In> oneOf,
            Func<T1In, T1Out> caseOne,
            Func<T2In, T2Out> caseTwo,
            Func<T3In, T3Out> caseThree,
            Func<T4In, T4Out> caseFour,
            Func<T5In, T5Out> caseFive,
            Func<T6In, T6Out> caseSix,
            Func<T7In, T7Out> caseSeven,
            Func<T8In, T8Out> caseEight,
            Func<T9In, T9Out> caseNine,
            Func<T10In, T10Out> caseTen)
    {
        if (oneOf.Is<T1In>()) return caseOne(oneOf.Get<T1In>());
        if (oneOf.Is<T2In>()) return caseTwo(oneOf.Get<T2In>());
        if (oneOf.Is<T3In>()) return caseThree(oneOf.Get<T3In>());
        if (oneOf.Is<T4In>()) return caseFour(oneOf.Get<T4In>());
        if (oneOf.Is<T5In>()) return caseFive(oneOf.Get<T5In>());
        if (oneOf.Is<T6In>()) return caseSix(oneOf.Get<T6In>());
        if (oneOf.Is<T7In>()) return caseSeven(oneOf.Get<T7In>());
        if (oneOf.Is<T8In>()) return caseEight(oneOf.Get<T8In>());
        if (oneOf.Is<T9In>()) return caseNine(oneOf.Get<T9In>());
        if (oneOf.Is<T10In>()) return caseTen(oneOf.Get<T10In>());
        throw new InvalidOperationException();
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out> Map
        <T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In, T10In, T11In, T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out>(
            this OneOf<T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In, T10In, T11In> oneOf,
            Func<T1In, T1Out> caseOne,
            Func<T2In, T2Out> caseTwo,
            Func<T3In, T3Out> caseThree,
            Func<T4In, T4Out> caseFour,
            Func<T5In, T5Out> caseFive,
            Func<T6In, T6Out> caseSix,
            Func<T7In, T7Out> caseSeven,
            Func<T8In, T8Out> caseEight,
            Func<T9In, T9Out> caseNine,
            Func<T10In, T10Out> caseTen,
            Func<T11In, T11Out> caseEleven)
    {
        if (oneOf.Is<T1In>()) return caseOne(oneOf.Get<T1In>());
        if (oneOf.Is<T2In>()) return caseTwo(oneOf.Get<T2In>());
        if (oneOf.Is<T3In>()) return caseThree(oneOf.Get<T3In>());
        if (oneOf.Is<T4In>()) return caseFour(oneOf.Get<T4In>());
        if (oneOf.Is<T5In>()) return caseFive(oneOf.Get<T5In>());
        if (oneOf.Is<T6In>()) return caseSix(oneOf.Get<T6In>());
        if (oneOf.Is<T7In>()) return caseSeven(oneOf.Get<T7In>());
        if (oneOf.Is<T8In>()) return caseEight(oneOf.Get<T8In>());
        if (oneOf.Is<T9In>()) return caseNine(oneOf.Get<T9In>());
        if (oneOf.Is<T10In>()) return caseTen(oneOf.Get<T10In>());
        if (oneOf.Is<T11In>()) return caseEleven(oneOf.Get<T11In>());
        throw new InvalidOperationException();
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out> Map
        <T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In, T10In, T11In, T12In, T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out>(
            this OneOf<T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In, T10In, T11In, T12In> oneOf,
            Func<T1In, T1Out> caseOne,
            Func<T2In, T2Out> caseTwo,
            Func<T3In, T3Out> caseThree,
            Func<T4In, T4Out> caseFour,
            Func<T5In, T5Out> caseFive,
            Func<T6In, T6Out> caseSix,
            Func<T7In, T7Out> caseSeven,
            Func<T8In, T8Out> caseEight,
            Func<T9In, T9Out> caseNine,
            Func<T10In, T10Out> caseTen,
            Func<T11In, T11Out> caseEleven,
            Func<T12In, T12Out> caseTwelve)
    {
        if (oneOf.Is<T1In>()) return caseOne(oneOf.Get<T1In>());
        if (oneOf.Is<T2In>()) return caseTwo(oneOf.Get<T2In>());
        if (oneOf.Is<T3In>()) return caseThree(oneOf.Get<T3In>());
        if (oneOf.Is<T4In>()) return caseFour(oneOf.Get<T4In>());
        if (oneOf.Is<T5In>()) return caseFive(oneOf.Get<T5In>());
        if (oneOf.Is<T6In>()) return caseSix(oneOf.Get<T6In>());
        if (oneOf.Is<T7In>()) return caseSeven(oneOf.Get<T7In>());
        if (oneOf.Is<T8In>()) return caseEight(oneOf.Get<T8In>());
        if (oneOf.Is<T9In>()) return caseNine(oneOf.Get<T9In>());
        if (oneOf.Is<T10In>()) return caseTen(oneOf.Get<T10In>());
        if (oneOf.Is<T11In>()) return caseEleven(oneOf.Get<T11In>());
        if (oneOf.Is<T12In>()) return caseTwelve(oneOf.Get<T12In>());
        throw new InvalidOperationException();
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out, T13Out> Map
        <T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In, T10In, T11In, T12In, T13In, T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out, T13Out>(
            this OneOf<T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In, T10In, T11In, T12In, T13In> oneOf,
            Func<T1In, T1Out> caseOne,
            Func<T2In, T2Out> caseTwo,
            Func<T3In, T3Out> caseThree,
            Func<T4In, T4Out> caseFour,
            Func<T5In, T5Out> caseFive,
            Func<T6In, T6Out> caseSix,
            Func<T7In, T7Out> caseSeven,
            Func<T8In, T8Out> caseEight,
            Func<T9In, T9Out> caseNine,
            Func<T10In, T10Out> caseTen,
            Func<T11In, T11Out> caseEleven,
            Func<T12In, T12Out> caseTwelve,
            Func<T13In, T13Out> caseThirteen)
    {
        if (oneOf.Is<T1In>()) return caseOne(oneOf.Get<T1In>());
        if (oneOf.Is<T2In>()) return caseTwo(oneOf.Get<T2In>());
        if (oneOf.Is<T3In>()) return caseThree(oneOf.Get<T3In>());
        if (oneOf.Is<T4In>()) return caseFour(oneOf.Get<T4In>());
        if (oneOf.Is<T5In>()) return caseFive(oneOf.Get<T5In>());
        if (oneOf.Is<T6In>()) return caseSix(oneOf.Get<T6In>());
        if (oneOf.Is<T7In>()) return caseSeven(oneOf.Get<T7In>());
        if (oneOf.Is<T8In>()) return caseEight(oneOf.Get<T8In>());
        if (oneOf.Is<T9In>()) return caseNine(oneOf.Get<T9In>());
        if (oneOf.Is<T10In>()) return caseTen(oneOf.Get<T10In>());
        if (oneOf.Is<T11In>()) return caseEleven(oneOf.Get<T11In>());
        if (oneOf.Is<T12In>()) return caseTwelve(oneOf.Get<T12In>());
        if (oneOf.Is<T13In>()) return caseThirteen(oneOf.Get<T13In>());
        throw new InvalidOperationException();
    }

}

public static class BindOneOfExtensions
{
    public static OneOf<T1Out, T2Out> Bind
        <T1In, T2In, T1Out, T2Out>(
        this OneOf<T1In, T2In> oneOf,
        Func<T1In, OneOf<T1Out, T2Out>> caseOne,
        Func<T2In, OneOf<T1Out, T2Out>> caseTwo)
    {
        var dict = new Dictionary<Func<bool>, Func<OneOf<T1Out, T2Out>>>
        {
            { oneOf.Is<T1In>, () => caseOne(oneOf.Get<T1In>()) },
            { oneOf.Is<T2In>, () => caseTwo(oneOf.Get<T2In>()) }
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }


    public static OneOf<T1Out, T2Out, T3Out> Bind
        <T1In, T2In, T3In, T1Out, T2Out, T3Out>(
            this OneOf<T1In, T2In, T3In> oneOf,
            Func<T1In, OneOf<T1Out, T2Out, T3Out>> caseOne,
            Func<T2In, OneOf<T1Out, T2Out, T3Out>> caseTwo,
            Func<T3In, OneOf<T1Out, T2Out, T3Out>> caseThree)
    {
        var dict = new Dictionary<Func<bool>, Func<OneOf<T1Out, T2Out, T3Out>>>
        {
            { oneOf.Is<T1In>, () => caseOne(oneOf.Get<T1In>()) },
            { oneOf.Is<T2In>, () => caseTwo(oneOf.Get<T2In>()) },
            { oneOf.Is<T3In>, () => caseThree(oneOf.Get<T3In>()) }
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out> Bind
        <T1In, T2In, T3In, T4In, T1Out, T2Out, T3Out, T4Out>(
            this OneOf<T1In, T2In, T3In, T4In> oneOf,
            Func<T1In, OneOf<T1Out, T2Out, T3Out, T4Out>> caseOne,
            Func<T2In, OneOf<T1Out, T2Out, T3Out, T4Out>> caseTwo,
            Func<T3In, OneOf<T1Out, T2Out, T3Out, T4Out>> caseThree,
            Func<T4In, OneOf<T1Out, T2Out, T3Out, T4Out>> caseFour)
    {
        var dict = new Dictionary<Func<bool>, Func<OneOf<T1Out, T2Out, T3Out, T4Out>>>
        {
            { oneOf.Is<T1In>, () => caseOne(oneOf.Get<T1In>()) },
            { oneOf.Is<T2In>, () => caseTwo(oneOf.Get<T2In>()) },
            { oneOf.Is<T3In>, () => caseThree(oneOf.Get<T3In>()) },
            { oneOf.Is<T4In>, () => caseFour(oneOf.Get<T4In>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out, T5Out> Bind
        <T1In, T2In, T3In, T4In, T5In, T1Out, T2Out, T3Out, T4Out, T5Out>(
            this OneOf<T1In, T2In, T3In, T4In, T5In> oneOf,
            Func<T1In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out>> caseOne,
            Func<T2In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out>> caseTwo,
            Func<T3In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out>> caseThree,
            Func<T4In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out>> caseFour,
            Func<T5In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out>> caseFive)
    {
        var dict = new Dictionary<Func<bool>, Func<OneOf<T1Out, T2Out, T3Out, T4Out, T5Out>>>
        {
            { oneOf.Is<T1In>, () => caseOne(oneOf.Get<T1In>()) },
            { oneOf.Is<T2In>, () => caseTwo(oneOf.Get<T2In>()) },
            { oneOf.Is<T3In>, () => caseThree(oneOf.Get<T3In>()) },
            { oneOf.Is<T4In>, () => caseFour(oneOf.Get<T4In>()) },
            { oneOf.Is<T5In>, () => caseFive(oneOf.Get<T5In>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out> Bind
        <T1In, T2In, T3In, T4In, T5In, T6In, T1Out, T2Out, T3Out, T4Out, T5Out, T6Out>(
            this OneOf<T1In, T2In, T3In, T4In, T5In, T6In> oneOf,
            Func<T1In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out>> caseOne,
            Func<T2In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out>> caseTwo,
            Func<T3In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out>> caseThree,
            Func<T4In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out>> caseFour,
            Func<T5In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out>> caseFive,
            Func<T6In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out>> caseSix)
    {
        var dict = new Dictionary<Func<bool>, Func<OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out>>>
        {
            { oneOf.Is<T1In>, () => caseOne(oneOf.Get<T1In>()) },
            { oneOf.Is<T2In>, () => caseTwo(oneOf.Get<T2In>()) },
            { oneOf.Is<T3In>, () => caseThree(oneOf.Get<T3In>()) },
            { oneOf.Is<T4In>, () => caseFour(oneOf.Get<T4In>()) },
            { oneOf.Is<T5In>, () => caseFive(oneOf.Get<T5In>()) },
            { oneOf.Is<T6In>, () => caseSix(oneOf.Get<T6In>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out> Bind
        <T1In, T2In, T3In, T4In, T5In, T6In, T7In, T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out>(
            this OneOf<T1In, T2In, T3In, T4In, T5In, T6In, T7In> oneOf,
            Func<T1In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out>> caseOne,
            Func<T2In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out>> caseTwo,
            Func<T3In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out>> caseThree,
            Func<T4In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out>> caseFour,
            Func<T5In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out>> caseFive,
            Func<T6In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out>> caseSix,
            Func<T7In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out>> caseSeven)
    {
        var dict = new Dictionary<Func<bool>, Func<OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out>>>
        {
            { oneOf.Is<T1In>, () => caseOne(oneOf.Get<T1In>()) },
            { oneOf.Is<T2In>, () => caseTwo(oneOf.Get<T2In>()) },
            { oneOf.Is<T3In>, () => caseThree(oneOf.Get<T3In>()) },
            { oneOf.Is<T4In>, () => caseFour(oneOf.Get<T4In>()) },
            { oneOf.Is<T5In>, () => caseFive(oneOf.Get<T5In>()) },
            { oneOf.Is<T6In>, () => caseSix(oneOf.Get<T6In>()) },
            { oneOf.Is<T7In>, () => caseSeven(oneOf.Get<T7In>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out> Bind
        <T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out>(
        this OneOf<T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In> oneOf,
        Func<T1In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out>> caseOne,
        Func<T2In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out>> caseTwo,
        Func<T3In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out>> caseThree,
        Func<T4In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out>> caseFour,
        Func<T5In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out>> caseFive,
        Func<T6In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out>> caseSix,
        Func<T7In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out>> caseSeven,
        Func<T8In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out>> caseEight)
    {
        var dict = new Dictionary<Func<bool>, Func<OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out>>>
        {
            { oneOf.Is<T1In>, () => caseOne(oneOf.Get<T1In>()) },
            { oneOf.Is<T2In>, () => caseTwo(oneOf.Get<T2In>()) },
            { oneOf.Is<T3In>, () => caseThree(oneOf.Get<T3In>()) },
            { oneOf.Is<T4In>, () => caseFour(oneOf.Get<T4In>()) },
            { oneOf.Is<T5In>, () => caseFive(oneOf.Get<T5In>()) },
            { oneOf.Is<T6In>, () => caseSix(oneOf.Get<T6In>()) },
            { oneOf.Is<T7In>, () => caseSeven(oneOf.Get<T7In>()) },
            { oneOf.Is<T8In>, () => caseEight(oneOf.Get<T8In>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out> Bind
        <T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In, T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out>(
        this OneOf<T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In> oneOf,
        Func<T1In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out>> caseOne,
        Func<T2In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out>> caseTwo,
        Func<T3In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out>> caseThree,
        Func<T4In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out>> caseFour,
        Func<T5In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out>> caseFive,
        Func<T6In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out>> caseSix,
        Func<T7In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out>> caseSeven,
        Func<T8In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out>> caseEight,
        Func<T9In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out>> caseNine)
    {
        var dict = new Dictionary<Func<bool>, Func<OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out>>>
        {
            { oneOf.Is<T1In>, () => caseOne(oneOf.Get<T1In>()) },
            { oneOf.Is<T2In>, () => caseTwo(oneOf.Get<T2In>()) },
            { oneOf.Is<T3In>, () => caseThree(oneOf.Get<T3In>()) },
            { oneOf.Is<T4In>, () => caseFour(oneOf.Get<T4In>()) },
            { oneOf.Is<T5In>, () => caseFive(oneOf.Get<T5In>()) },
            { oneOf.Is<T6In>, () => caseSix(oneOf.Get<T6In>()) },
            { oneOf.Is<T7In>, () => caseSeven(oneOf.Get<T7In>()) },
            { oneOf.Is<T8In>, () => caseEight(oneOf.Get<T8In>()) },
            { oneOf.Is<T9In>, () => caseNine(oneOf.Get<T9In>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out> Bind
        <T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In, T10In, T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out>(
        this OneOf<T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In, T10In> oneOf,
        Func<T1In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out>> caseOne,
        Func<T2In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out>> caseTwo,
        Func<T3In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out>> caseThree,
        Func<T4In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out>> caseFour,
        Func<T5In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out>> caseFive,
        Func<T6In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out>> caseSix,
        Func<T7In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out>> caseSeven,
        Func<T8In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out>> caseEight,
        Func<T9In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out>> caseNine,
        Func<T10In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out>> caseTen)
    {
        var dict = new Dictionary<Func<bool>, Func<OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out>>>
        {
            { oneOf.Is<T1In>, () => caseOne(oneOf.Get<T1In>()) },
            { oneOf.Is<T2In>, () => caseTwo(oneOf.Get<T2In>()) },
            { oneOf.Is<T3In>, () => caseThree(oneOf.Get<T3In>()) },
            { oneOf.Is<T4In>, () => caseFour(oneOf.Get<T4In>()) },
            { oneOf.Is<T5In>, () => caseFive(oneOf.Get<T5In>()) },
            { oneOf.Is<T6In>, () => caseSix(oneOf.Get<T6In>()) },
            { oneOf.Is<T7In>, () => caseSeven(oneOf.Get<T7In>()) },
            { oneOf.Is<T8In>, () => caseEight(oneOf.Get<T8In>()) },
            { oneOf.Is<T9In>, () => caseNine(oneOf.Get<T9In>()) },
            { oneOf.Is<T10In>, () => caseTen(oneOf.Get<T10In>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out> Bind
        <T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In, T10In, T11In, T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out>(
        this OneOf<T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In, T10In, T11In> oneOf,
        Func<T1In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out>> caseOne,
        Func<T2In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out>> caseTwo,
        Func<T3In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out>> caseThree,
        Func<T4In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out>> caseFour,
        Func<T5In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out>> caseFive,
        Func<T6In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out>> caseSix,
        Func<T7In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out>> caseSeven,
        Func<T8In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out>> caseEight,
        Func<T9In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out>> caseNine,
        Func<T10In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out>> caseTen,
        Func<T11In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out>> caseEleven)
    {
        var dict = new Dictionary<Func<bool>, Func<OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out>>>
        {
            { oneOf.Is<T1In>, () => caseOne(oneOf.Get<T1In>()) },
            { oneOf.Is<T2In>, () => caseTwo(oneOf.Get<T2In>()) },
            { oneOf.Is<T3In>, () => caseThree(oneOf.Get<T3In>()) },
            { oneOf.Is<T4In>, () => caseFour(oneOf.Get<T4In>()) },
            { oneOf.Is<T5In>, () => caseFive(oneOf.Get<T5In>()) },
            { oneOf.Is<T6In>, () => caseSix(oneOf.Get<T6In>()) },
            { oneOf.Is<T7In>, () => caseSeven(oneOf.Get<T7In>()) },
            { oneOf.Is<T8In>, () => caseEight(oneOf.Get<T8In>()) },
            { oneOf.Is<T9In>, () => caseNine(oneOf.Get<T9In>()) },
            { oneOf.Is<T10In>, () => caseTen(oneOf.Get<T10In>()) },
            { oneOf.Is<T11In>, () => caseEleven(oneOf.Get<T11In>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out> Bind
        <T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In, T10In, T11In, T12In, T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out>(
        this OneOf<T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In, T10In, T11In, T12In> oneOf,
        Func<T1In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out>> caseOne,
        Func<T2In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out>> caseTwo,
        Func<T3In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out>> caseThree,
        Func<T4In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out>> caseFour,
        Func<T5In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out>> caseFive,
        Func<T6In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out>> caseSix,
        Func<T7In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out>> caseSeven,
        Func<T8In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out>> caseEight,
        Func<T9In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out>> caseNine,
        Func<T10In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out>> caseTen,
        Func<T11In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out>> caseEleven,
        Func<T12In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out>> caseTwelve)
    {
        var dict = new Dictionary<Func<bool>, Func<OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out>>>
        {
            { oneOf.Is<T1In>, () => caseOne(oneOf.Get<T1In>()) },
            { oneOf.Is<T2In>, () => caseTwo(oneOf.Get<T2In>()) },
            { oneOf.Is<T3In>, () => caseThree(oneOf.Get<T3In>()) },
            { oneOf.Is<T4In>, () => caseFour(oneOf.Get<T4In>()) },
            { oneOf.Is<T5In>, () => caseFive(oneOf.Get<T5In>()) },
            { oneOf.Is<T6In>, () => caseSix(oneOf.Get<T6In>()) },
            { oneOf.Is<T7In>, () => caseSeven(oneOf.Get<T7In>()) },
            { oneOf.Is<T8In>, () => caseEight(oneOf.Get<T8In>()) },
            { oneOf.Is<T9In>, () => caseNine(oneOf.Get<T9In>()) },
            { oneOf.Is<T10In>, () => caseTen(oneOf.Get<T10In>()) },
            { oneOf.Is<T11In>, () => caseEleven(oneOf.Get<T11In>()) },
            { oneOf.Is<T12In>, () => caseTwelve(oneOf.Get<T12In>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

    public static OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out, T13Out> Bind
        <T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In, T10In, T11In, T12In, T13In, T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out, T13Out>(
        this OneOf<T1In, T2In, T3In, T4In, T5In, T6In, T7In, T8In, T9In, T10In, T11In, T12In, T13In> oneOf,
        Func<T1In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out, T13Out>> caseOne,
        Func<T2In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out, T13Out>> caseTwo,
        Func<T3In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out, T13Out>> caseThree,
        Func<T4In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out, T13Out>> caseFour,
        Func<T5In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out, T13Out>> caseFive,
        Func<T6In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out, T13Out>> caseSix,
        Func<T7In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out, T13Out>> caseSeven,
        Func<T8In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out, T13Out>> caseEight,
        Func<T9In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out, T13Out>> caseNine,
        Func<T10In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out, T13Out>> caseTen,
        Func<T11In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out, T13Out>> caseEleven,
        Func<T12In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out, T13Out>> caseTwelve,
        Func<T13In, OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out, T13Out>> caseThirteen)
    {
        var dict = new Dictionary<Func<bool>, Func<OneOf<T1Out, T2Out, T3Out, T4Out, T5Out, T6Out, T7Out, T8Out, T9Out, T10Out, T11Out, T12Out, T13Out>>>
        {
            { oneOf.Is<T1In>, () => caseOne(oneOf.Get<T1In>()) },
            { oneOf.Is<T2In>, () => caseTwo(oneOf.Get<T2In>()) },
            { oneOf.Is<T3In>, () => caseThree(oneOf.Get<T3In>()) },
            { oneOf.Is<T4In>, () => caseFour(oneOf.Get<T4In>()) },
            { oneOf.Is<T5In>, () => caseFive(oneOf.Get<T5In>()) },
            { oneOf.Is<T6In>, () => caseSix(oneOf.Get<T6In>()) },
            { oneOf.Is<T7In>, () => caseSeven(oneOf.Get<T7In>()) },
            { oneOf.Is<T8In>, () => caseEight(oneOf.Get<T8In>()) },
            { oneOf.Is<T9In>, () => caseNine(oneOf.Get<T9In>()) },
            { oneOf.Is<T10In>, () => caseTen(oneOf.Get<T10In>()) },
            { oneOf.Is<T11In>, () => caseEleven(oneOf.Get<T11In>()) },
            { oneOf.Is<T12In>, () => caseTwelve(oneOf.Get<T12In>()) },
            { oneOf.Is<T13In>, () => caseThirteen(oneOf.Get<T13In>()) },
        };

        var result = dict.First(x => x.Key()).Value();
        return result;
    }

}