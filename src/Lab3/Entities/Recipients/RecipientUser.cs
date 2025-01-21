namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;

public class RecipientUser : IRecipient
{
    private readonly User _user;

    public RecipientUser(User user)
    {
        _user = user;
    }

    public void ReceiveMessage(Message message)
    {
        _user.OutputMessage(message);
    }
}