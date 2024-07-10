namespace BrightSky.SharedKernel;

public static class Precondition
{
    public static Result<TValue, Error> Requires<TValue>(TValue value) => Result<TValue, Error>.Success(value);

    public static Result<TValue, Error> BeTrueFor<TValue>(this Result<TValue, Error> result, Func<TValue, bool> predicate)
        => result.IsFailure ? result : predicate(result.Value) 
            ? result 
            : Result<TValue, Error>.Failure(Error.Failure(
                "Precondition.BeTrueFor", 
                "Func<TValue, bool> predicate was false"));


    public static Result<TValue, Error> BeFalseFor<TValue>(this Result<TValue, Error> result, Func<TValue, bool> predicate)
        => result.IsFailure ? result : !predicate(result.Value) 
            ? result 
            : Result<TValue, Error>.Failure(Error.Failure(
                "Precondition.BeFalseFor", 
                "Func<TValue, bool> predicate was true"));    
    
    public static Option<Error> OrError<TValue>(this Result<TValue, Error> result)
        => result.IsFailure ? Option<Error>.Some(result.Error) : Option<Error>.None;
    
    public static Option<Error> OrError<TValue>(this Result<TValue, Error> result, Error error)
        => result.IsFailure ? Option<Error>.Some(error) : Option<Error>.None;

}