using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Facade;
using Itmo.ObjectOrientedProgramming.Lab3.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Result;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class UserHasMessage
{
    [Fact]
    public void Scenario1()
    {
        var mockLogger = new Mock<ILogger>();
        var factory = new MessageComponentFactory(mockLogger.Object);
        var facade = new MessageSystemFacade(factory);

        User user = factory.CreateUser();
        IRecipient recipientUser = factory.CreateUserRecipient(user);

        Topic topic = factory.CreateTopic("User notification", recipientUser);

        Message message = factory.CreateMessage("Arseniy", "Hello!", Level.Medium);

        facade.SendMessageToTopic(topic, message);

        IReadOnlyCollection<MessageStatus> savedMessages = user.GetMessages();
        Assert.Single(savedMessages);
        Assert.Equal(IsStatus.Unread, savedMessages.First().IsStatus);
    }

    [Fact]
    public void Scenario2()
    {
        var mockLogger = new Mock<ILogger>();
        var factory = new MessageComponentFactory(mockLogger.Object);
        var facade = new MessageSystemFacade(factory);

        User user = factory.CreateUser();
        IRecipient recipientUser = factory.CreateUserRecipient(user);

        Topic topic = factory.CreateTopic("User notification", recipientUser);

        Message message = factory.CreateMessage("Arseniy", "Hello!", Level.Medium);

        facade.SendMessageToTopic(topic, message);
        user.MarkAsRead(message);

        IReadOnlyCollection<MessageStatus> savedMessages = user.GetMessages();
        Assert.Single(savedMessages);
        Assert.Equal(IsStatus.Read, savedMessages.First().IsStatus);
    }

    [Fact]
    public void Scenario3()
    {
        var mockLogger = new Mock<ILogger>();
        var factory = new MessageComponentFactory(mockLogger.Object);
        var facade = new MessageSystemFacade(factory);

        User user = factory.CreateUser();
        IRecipient recipientUser = factory.CreateUserRecipient(user);

        Topic topic = factory.CreateTopic("User notification", recipientUser);

        Message message = factory.CreateMessage("Arseniy", "Hello!", Level.Medium);

        facade.SendMessageToTopic(topic, message);
        user.MarkAsRead(message);

        ResultType result = user.MarkAsRead(message);

        Assert.False(result.Success);
        Assert.Equal("The message is already read", result.ErrorMessage);
    }
}
