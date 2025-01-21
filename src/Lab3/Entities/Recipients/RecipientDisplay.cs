using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;

public class RecipientDisplay : IRecipient
{
    private readonly Display _display;

    public RecipientDisplay(Display display)
    {
        _display = display;
    }

    public void ReceiveMessage(Message message)
    {
        _display.OutputMessage(message);
    }
}