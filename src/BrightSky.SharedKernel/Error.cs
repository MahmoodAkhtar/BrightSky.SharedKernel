namespace BrightSky.SharedKernel;

public record ErrorType : Enumeration<ErrorType, int>
{
    public static ErrorType None => new(nameof(None), 0);
    public static ErrorType Failure => new(nameof(Failure), 1);
    public static ErrorType Unexpected => new(nameof(Unexpected), 2);
    public static ErrorType Validation => new(nameof(Validation), 3);
    public static ErrorType Conflict => new(nameof(Conflict), 4);
    public static ErrorType NotFound => new(nameof(NotFound), 5);
    public static ErrorType Unauthenticated => new(nameof(Unauthenticated), 6);
    public static ErrorType Unauthorized => new(nameof(Unauthorized), 7);
    
    private ErrorType(string name, int value) : base(name, value)
    {
    }
}

public readonly record struct Error
{
    public static Error None => new(string.Empty, string.Empty, ErrorType.None);
    
    public readonly string Code;
    public readonly string Description;
    public readonly ErrorType Type;

    private Error(string code, string description, ErrorType type)
        => (Code, Description, Type) = (code, description, type);

    public static Error Failure(string code, string description)
        => new(code, description, ErrorType.Failure);

    public static Error Unexpected(string code, string description)
        => new(code, description, ErrorType.Unexpected);

    public static Error Validation(string code, string description)
        => new(code, description, ErrorType.Validation);

    public static Error Conflict(string code, string description)
        => new(code, description, ErrorType.Conflict);

    public static Error NotFound(string code, string description)
        => new(code, description, ErrorType.NotFound);

    public static Error Unauthenticated(string code, string description)
        => new(code, description, ErrorType.Unauthenticated);

    public static Error Unauthorized(string code, string description)
        => new(code, description, ErrorType.Unauthorized);

    public static Error FromException(Exception e)
        => Unexpected(e.GetType().Name, $"{e.Message} {e.StackTrace}");
}