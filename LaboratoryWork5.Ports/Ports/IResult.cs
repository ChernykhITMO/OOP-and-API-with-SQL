namespace LaboratoryWork5.Ports.Ports;

public interface IResult<T>
{
    bool IsSuccess { get; }

    string? ErrorMessage { get; }

    T? Value { get; }
}
