namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;

public class RecipientGroup : IRecipient
{
    private readonly List<IRecipient> _recipients = new List<IRecipient>();

    public void AddRecipient(IRecipient recipient)
    {
        if (recipient is null)
            throw new ArgumentNullException(nameof(recipient), "Recipient cannot be null.");

        _recipients.Add(recipient);
    }

    public void RemoveRecipient(IRecipient recipient)
    {
        if (recipient is null)
            throw new ArgumentNullException(nameof(recipient), "Recipient cannot be null.");

        _recipients.Remove(recipient);
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IRecipient rec in _recipients)
        {
            rec.ReceiveMessage(message);
        }
    }
}