using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Facade;
using Itmo.ObjectOrientedProgramming.Lab3.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class MultipleRecipientsTests
{
    [Fact]
    public void Scenario7()
    {
        var mockLogger = new Mock<ILogger>();
        var factory = new MessageComponentFactory(mockLogger.Object);
        var facade = new MessageSystemFacade(factory);

        User user = factory.CreateUser();

        IRecipient recipientWithoutFilter = factory.CreateUserRecipient(user);
        IRecipient recipientWithFilter = factory.CreateFilteredRecipient(recipientWithoutFilter, Level.High);

        IRecipient groupRecipient = factory.CreateGroupRecipient(new[] { recipientWithoutFilter, recipientWithFilter });

        Topic topic = factory.CreateTopic("Group Notification", groupRecipient);

        Message lowPriorityMessage = factory.CreateMessage("Low Priority", "This is a low priority message", Level.Low);

        facade.SendMessageToTopic(topic, lowPriorityMessage);

        IReadOnlyList<MessageStatus> receivedMessages = user.GetMessages();
        Assert.Single(receivedMessages);
        Assert.Equal(IsStatus.Unread, receivedMessages.First().IsStatus);
        Assert.Equal("Low Priority", receivedMessages.First().Message.Header);
    }
}