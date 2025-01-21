namespace Itmo.ObjectOrientedProgramming.Lab4.InputOutputStrategy;

public class ConsoleInputOutput : IInputOutput
{
    public string ReadLine()
    {
        return Console.ReadLine() ?? throw new InvalidOperationException();
    }

    public void WriteLine(string value)
    {
        Console.WriteLine(value);
    }
}