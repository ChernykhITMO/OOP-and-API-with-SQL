namespace Itmo.ObjectOrientedProgramming.Lab3.Result;

public class ResultType
{
    public bool Success { get; }

    public string ErrorMessage { get; }

    public ResultType()
    {
        Success = true;
        ErrorMessage = string.Empty;
    }

    public ResultType(string errorMessage)
    {
        Success = false;
        ErrorMessage = errorMessage;
    }
}
