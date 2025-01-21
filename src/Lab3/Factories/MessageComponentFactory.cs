using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients.Decorator;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Factories;

public class MessageComponentFactory
{
    private readonly ILogger _logger;

    public MessageComponentFactory(ILogger logger)
    {
        _logger = logger;
    }

    public User CreateUser()
    {
        return new User();
    }

    public IRecipient CreateUserRecipient(User user)
    {
        return new RecipientUser(user);
    }

    public IRecipient CreateMessengerRecipient()
    {
        var messenger = new Messenger();
        return new RecipientMessenger(messenger);
    }

    public IRecipient CreateDisplayRecipient(IDisplayDriver displayDriver, string color)
    {
        var display = new Display(displayDriver, color);
        return new RecipientDisplay(display);
    }

    public IRecipient CreateGroupRecipient(IEnumerable<IRecipient> recipients)
    {
        var group = new RecipientGroup();
        foreach (IRecipient recipient in recipients)
        {
            group.AddRecipient(recipient);
        }

        return group;
    }

    public IRecipient CreateFilteredRecipient(IRecipient recipient, Level filterLevel)
    {
        return new FilteredRecipient(recipient, filterLevel);
    }

    public IRecipient CreateLoggingRecipient(IRecipient recipient)
    {
        return new LoggingRecipient(recipient, _logger);
    }

    public Message CreateMessage(string header, string body, Level importanceLevel)
    {
        return new Message(header, body, importanceLevel);
    }

    public Topic CreateTopic(string topicName, IRecipient recipient)
    {
        return new Topic(topicName, recipient);
    }
}