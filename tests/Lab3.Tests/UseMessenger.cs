using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Facade;
using Itmo.ObjectOrientedProgramming.Lab3.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class UseMessenger
{
    [Fact]
    public void Scenario6()
    {
        var mockLogger = new Mock<ILogger>();
        var factory = new MessageComponentFactory(mockLogger.Object);
        var facade = new MessageSystemFacade(factory);

        var mockMessenger = new Mock<IMessageOutput>();
        IRecipient messengerRecipient = new RecipientMessenger(mockMessenger.Object);

        Topic topic = factory.CreateTopic("Messenger Notifications", messengerRecipient);
        Message message = factory.CreateMessage("Test Header", "Test Body", Level.Medium);

        facade.SendMessageToTopic(topic, message);

        mockMessenger.Verify(m => m.OutputMessage(message), Times.Once);
    }
}