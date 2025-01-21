using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Facade;

public class MessageSystemFacade
{
    private readonly MessageComponentFactory _factory;

    public MessageSystemFacade(MessageComponentFactory factory)
    {
        _factory = factory;
    }

    public void SendMessageToTopic(Topic topic, Message message)
    {
        topic.SendMessage(message);
    }

    public User SetupUserWithMessageTracking()
    {
        User user = _factory.CreateUser();
        IRecipient recipient = _factory.CreateUserRecipient(user);
        return user;
    }

    public Topic CreateTopicWithLogging(string topicName, IRecipient recipient)
    {
        IRecipient loggingRecipient = _factory.CreateLoggingRecipient(recipient);
        return _factory.CreateTopic(topicName, loggingRecipient);
    }
}