using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic
{
    public string TopicName { get; private set; }

    private readonly IRecipient _recipient;

    public Topic(string name, IRecipient recipient)
    {
        TopicName = name;
        _recipient = recipient;
    }

    public void SendMessage(Message message)
    {
        _recipient.ReceiveMessage(message);
    }
}