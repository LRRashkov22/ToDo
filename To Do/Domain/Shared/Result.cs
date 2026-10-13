namespace To_Do.Domain.Shared;

public class Result<T>
{
    public T? Value { get; init; }
    public string? Error { get; init; }
    public bool Success { get; init; }

    public static Result<T> Ok(T value)
    {
        return new Result<T>
        {
            Success = true,
            Value = value
        };
    }
    public static Result<T> Fail(string error)
    {
        return new Result<T>
        {
            Success = false,
            Error = error
        };
    }
}
