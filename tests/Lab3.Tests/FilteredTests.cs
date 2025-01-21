using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Facade;
using Itmo.ObjectOrientedProgramming.Lab3.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class FilteredTests
{
    [Fact]
    public void Scenario4()
    {
        var mockLogger = new Mock<ILogger>();
        var factory = new MessageComponentFactory(mockLogger.Object);
        var facade = new MessageSystemFacade(factory);

        var mockRecipient = new Mock<IRecipient>();
        IRecipient filteredRecipient = factory.CreateFilteredRecipient(mockRecipient.Object, Level.High);

        Topic topic = factory.CreateTopic("Important Notifications", filteredRecipient);

        Message lowPriorityMessage = factory.CreateMessage("Low Priority", "This is a low priority message", Level.Low);

        facade.SendMessageToTopic(topic, lowPriorityMessage);

        mockRecipient.Verify(r => r.ReceiveMessage(It.IsAny<Message>()), Times.Never);
    }
}