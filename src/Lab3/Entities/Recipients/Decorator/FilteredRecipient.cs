namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients.Decorator;

public class FilteredRecipient : IRecipient
{
    private readonly IRecipient _recipient;

    private readonly Level _filterLevel;

    public FilteredRecipient(IRecipient recipient, Level filterLevel)
    {
        _recipient = recipient;
        _filterLevel = filterLevel;
    }

    public void ReceiveMessage(Message message)
    {
        if (message.ImportanceLevel >= _filterLevel)
            _recipient.ReceiveMessage(message);
    }
}