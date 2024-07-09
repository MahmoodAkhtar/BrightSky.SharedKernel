namespace BrightSky.SharedKernel;

public readonly record struct Error
{
    public static Error None => new(string.Empty, string.Empty, ErrorType.None);
    
    public readonly string Code;
    public readonly string Description;
    public readonly ErrorType Type;

    private Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
    }

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

public enum ErrorType
{
    /// <summary>
    /// Precondition and or an attempt for an external resource failed
    /// </summary>
    Failure,
    
    /// <summary>
    /// Actual exception occured in the system
    /// </summary>
    Unexpected,
    
    /// <summary>
    /// Validation failed
    /// </summary>
    Validation,
    
    /// <summary>
    /// System state has progressed therefore unable to carry out desired action 
    /// </summary>
    Conflict,
    
    /// <summary>
    /// Expected system resource is not found
    /// </summary>
    NotFound,
    
    /// <summary>
    /// Not authenticated
    /// </summary>
    Unauthenticated,
    
    /// <summary>
    /// Don't have permissions to carry out desired action
    /// </summary>
    Unauthorized,
    
    /// <summary>
    /// For a None Error
    /// </summary>
    None
}