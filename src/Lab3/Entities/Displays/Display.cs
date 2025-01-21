namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class Display : IMessageOutput
{
    private readonly IDisplayDriver _displayDriver;

    private readonly string _color;

    public Display(IDisplayDriver displayDriver, string color)
    {
        _displayDriver = displayDriver;
        _color = color;
    }

    public void OutputMessage(Message message)
    {
        _displayDriver.Clear();
        _displayDriver.SetColorText(_color);
        _displayDriver.AddText(message.Body);
    }
}