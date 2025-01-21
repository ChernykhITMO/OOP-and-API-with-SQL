namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class ConsoleDisplayDriver : IDisplayDriver
{
    public void Clear() => Console.Clear();

    public void SetColorText(string color)
    {
        Console.ForegroundColor = color switch
        {
            "Red" => ConsoleColor.Red,
            "Green" => ConsoleColor.Green,
            "Blue" => ConsoleColor.Blue,
            _ => ConsoleColor.White,
        };
    }

    public void AddText(string text)
    {
        Console.Write(text);
        Console.ResetColor();
    }
}