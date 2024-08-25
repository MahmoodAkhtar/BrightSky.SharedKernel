namespace BrightSky.SharedKernel;

public static class Precondition
{
    public static Result<TValue, Error> Requires<TValue>(TValue value) => Result<TValue, Error>.Success(value);

    public static Result<TValue, Option<Error>> Meets
        <TValue>(
            this Result<TValue, Error> result,
            Specification<TValue> specification)
        => result.Match(
            success => 
                specification.IsSatisfiedBy(success)
                    ? success
                    : Result<TValue, Option<Error>>.Failure(Error.Failure(
                        $"Precondition.{specification.GetType().Name}",
                        $"Specification {specification.GetType().Name} was not met")),
            failure => Result<TValue, Option<Error>>.Failure(failure));
    
    public static TValue ThenAssignOrThrow<TValue, TException>(this Result<TValue, Option<Error>> result)
        where TException : Exception
        => result
            .Match<TValue, Option<Error>, Result<TValue, Option<TException>>>(
                success => success,
                failure => failure
                    .Map(error => (TException)Activator.CreateInstance(typeof(TException),
                        $"{Error.GetNameFor(error.Type)} {error.Code} {error.Description}")!)
                    .Tap(exception => throw exception))
            .Match(
                success => success,
                failure => default!);
}