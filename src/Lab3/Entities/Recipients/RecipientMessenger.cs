namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;

public class RecipientMessenger : IRecipient
{
    private readonly IMessageOutput _messenger;

    public RecipientMessenger(IMessageOutput messenger)
    {
        _messenger = messenger;
    }

    public void ReceiveMessage(Message message)
    {
        _messenger.OutputMessage(message);
    }
}