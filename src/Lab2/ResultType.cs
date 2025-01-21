namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ResultType<T>
{
    public bool IsSuccess { get; }

    public string Error { get; set; }

    public T? Value { get; }

    public ResultType(T? value, bool isSuccess, string error)
    {
        Value = value;
        IsSuccess = isSuccess;
        Error = error;
    }

    public ResultType<T> Success(T value)
    {
        return new ResultType<T>(value, true, string.Empty);
    }

    public ResultType<T> Failure(string error)
    {
        return new ResultType<T>(default, false, error);
    }
}