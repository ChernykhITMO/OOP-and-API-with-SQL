using LaboratoryWork5.Ports.Ports;

namespace Logic;

public class Result<T> : IResult<T>
{
    public bool IsSuccess { get; private set; }

    public string? ErrorMessage { get; private set; }

    public T? Value { get; private set; }

    public Result(bool isSuccess, T? value = default, string? errorMessage = null)
    {
        IsSuccess = isSuccess;
        Value = value;
        ErrorMessage = errorMessage;
    }
}
