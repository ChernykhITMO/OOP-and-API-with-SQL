using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Facade;
using Itmo.ObjectOrientedProgramming.Lab3.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class LoggingRecipientTests
{
    [Fact]
    public void Scenario5()
    {
        var mockLogger = new Mock<ILogger>();
        var factory = new MessageComponentFactory(mockLogger.Object);
        var facade = new MessageSystemFacade(factory);

        var mockRecipient = new Mock<IRecipient>();
        IRecipient loggingRecipient = factory.CreateLoggingRecipient(mockRecipient.Object);

        Topic topic = factory.CreateTopic("TestTopic", loggingRecipient);
        Message message = factory.CreateMessage("Test Header", "Test Body", Level.Medium);

        facade.SendMessageToTopic(topic, message);

        mockLogger.Verify(logger => logger.Log(It.IsAny<string>()), Times.Once);
        mockRecipient.Verify(r => r.ReceiveMessage(message), Times.Once);
    }
}