namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Messenger : IMessageOutput
{
    public void OutputMessage(Message message)
    {
        Console.WriteLine($"Messenger: sent message with header '{message.Header}', priority '{message.ImportanceLevel}', body '{message.Body}'");
    }
}