using Itmo.ObjectOrientedProgramming.Lab3.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients.Decorator;

public class LoggingRecipient : IRecipient
{
    private readonly IRecipient _recipient;

    private readonly ILogger _logger;

    public LoggingRecipient(IRecipient recipient, ILogger logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public void ReceiveMessage(Message message)
    {
        _logger.Log($"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}] {_recipient.GetType().Name} received message | Header: '{message.Header}'");
        _recipient.ReceiveMessage(message);
    }
}