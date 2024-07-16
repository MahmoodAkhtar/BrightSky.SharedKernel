namespace BrightSky.SharedKernel;

public readonly record struct Result<TValue, TError>
{
    public readonly TValue? Value;
    public readonly TError? Error;

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    private Result(TValue value) => (Value, Error, IsSuccess) = (value, default, true);
    private Result(TError error) => (Value, Error, IsSuccess) = (default, error, false);

    public static Result<TValue, TError> Success(TValue value) => new(value);
    public static Result<TValue, TError> Failure(TError error) => new(error);

    public static implicit operator Result<TValue, TError>(TValue value) => Success(value);
    public static implicit operator Result<TValue, TError>(TError error) => Failure(error);
}

public static class ResultExtensions
{
    public static TResult Match<TValue, TError, TResult>(
        this Result<TValue, TError> result,
        Func<TValue, TResult> success,
        Func<TError, TResult> failure) 
        => result.IsSuccess ? success(result.Value!) : failure(result.Error!);
    
    public static Result<TOut, TError> Bind<TIn, TError, TOut>(
        this Result<TIn, TError> result,
        Func<TIn, Result<TOut, TError>> bind)
        => result.Match(bind, error => error);

    public static Result<TIn, TError> Ensure<TIn, TError>(
        this Result<TIn, TError> result,
        Func<TIn, bool> predicate,
        TError error)
        => result.Match(success => predicate(success) ? result : error, _ => result);

    public static Result<TIn, TError> Ensure<TIn, TError>(
        this Result<TIn, TError> result,
        params (Func<TIn, bool> predicate, TError error)[] predicates)
    {
        var results = new List<Result<TIn, TError>>();
        predicates.ToList().ForEach(t => results.Add(Ensure(result.Value!, t.predicate, t.error)));
        
        return Combine(results);
    }

    public static Result<TOut, TError> Map<TIn, TError, TOut>(
        this Result<TIn, TError> result,
        Func<TIn, TOut> map)
        => result.Match(success => Result<TOut, TError>.Success(map(success)), Result<TOut, TError>.Failure);

    public static Result<TIn, TError> Tap<TIn, TError>(
        this Result<TIn, TError> result,
        Action<TIn> action)
    {
        if (result.IsSuccess) action(result.Value!);
        return result;
    }

    public static Result<TOut, TError> TryCatch<TIn, TError, TOut>(
        this Result<TIn, TError> result,
        Func<TIn, TOut> tryMap,
        TError catchError)
    {
        try
        {
            return result.Match(success => Result<TOut, TError>.Success(tryMap(success)), Result<TOut, TError>.Failure); //result.IsSuccess ? tryMap(result.Value!) : result.Error!;
        }
        catch
        {
            return catchError;
        }
    }

    public static Result<TOut, TError> TryCatch<TIn, TError, TOut>(
        this Result<TIn, TError> result,
        Func<TIn, TOut> tryMap,
        Func<Exception, TError> catchMapException)
    {
        try
        {
            return result.Match(success => Result<TOut, TError>.Success(tryMap(success)), Result<TOut, TError>.Failure); //result.IsSuccess ? tryMap(result.Value!) : result.Error!;
        }
        catch (Exception e)
        {
            return catchMapException(e);
        }
    }

    public static Result<TOut, TError> TryCatch<TIn, TError, TOut>(
        this Result<TIn, TError> result,
        Func<TIn, TOut> tryMap,
        Action<Exception> catchAction,
        TError catchError)
    {
        try
        {
            return result.Match(success => Result<TOut, TError>.Success(tryMap(success)), Result<TOut, TError>.Failure); //result.IsSuccess ? tryMap(result.Value!) : result.Error!;
        }
        catch (Exception e)
        {
            catchAction(e);
            return catchError;
        }
    }

    public static Result<TOut, TError> TryCatch<TIn, TError, TOut>(
        this Result<TIn, TError> result,
        Func<TIn, TOut> tryMap,
        Action<Exception> catchAction,
        Func<Exception, TError> catchMapException)
    {
        try
        {
            return result.Match(success => Result<TOut, TError>.Success(tryMap(success)), Result<TOut, TError>.Failure); //result.IsSuccess ? tryMap(result.Value!) : result.Error!;
        }
        catch (Exception e)
        {
            catchAction(e);
            return catchMapException(e);
        }
    }
    
    public static Result<TValue, TError> Combine<TValue, TError>(
        this Result<TValue, TError>[] results)
        => results.Any(x => x.IsFailure)
            ? results.Select(x => x.Error!).First() 
            : results[0].Value!;

    public static Result<TValue, TError> Combine<TValue, TError>(
        this IEnumerable<Result<TValue, TError>> results)
        => Combine(results.ToArray());
}
