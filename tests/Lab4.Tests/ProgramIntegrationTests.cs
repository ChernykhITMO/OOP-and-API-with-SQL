using Itmo.ObjectOrientedProgramming.Lab4;
using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.InputOutputStrategy;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Moq;
using Xunit;

namespace Lab4.Tests;

public class ProgramIntegrationTests
{
    [Fact]
    public void Run_Should_Execute_All_Commands_Correctly_And_Exit()
    {
        var mockInputOutput = new Mock<IInputOutput>();
        var mockFileSystem = new Mock<IFileSystem>();
        bool exitCalled = false;

        void ExitAction() => exitCalled = true;

        var parser = new CommandParser(mockFileSystem.Object, mockInputOutput.Object, ExitAction);
        var program = new Program();

        mockInputOutput.SetupSequence(io => io.ReadLine())
            .Returns("connect C:\\ -m local")
            .Returns("tree list -d 1")
            .Returns("file copy C:\\source.txt D:\\destination.txt")
            .Returns("file delete D:\\destination.txt")
            .Returns("disconnect")
            .Returns("exit");

        mockFileSystem.Setup(fs => fs.Connect("C:\\")).Verifiable();
        mockFileSystem.Setup(fs => fs.TreeList(1)).Verifiable();
        mockFileSystem.Setup(fs => fs.Copy("C:\\source.txt", "D:\\destination.txt")).Verifiable();
        mockFileSystem.Setup(fs => fs.Delete("D:\\destination.txt")).Verifiable();
        mockFileSystem.Setup(fs => fs.Disconnect()).Verifiable();

        mockInputOutput.Setup(io => io.WriteLine("> ")).Verifiable();
        mockInputOutput.Setup(io => io.WriteLine(It.IsAny<string>())).Verifiable();

        var runTask = Task.Run(() => program.Run(mockInputOutput.Object, parser));

        while (!exitCalled)
        {
            Thread.Sleep(100);
        }

        mockFileSystem.Verify(fs => fs.Connect("C:\\"), Times.Once);
        mockFileSystem.Verify(fs => fs.TreeList(1), Times.Once);
        mockFileSystem.Verify(fs => fs.Copy("C:\\source.txt", "D:\\destination.txt"), Times.Once);
        mockFileSystem.Verify(fs => fs.Delete("D:\\destination.txt"), Times.Once);
        mockFileSystem.Verify(fs => fs.Disconnect(), Times.Once);

        mockInputOutput.Verify(io => io.WriteLine("> "), Times.Exactly(6));
        mockInputOutput.Verify(io => io.WriteLine(It.IsAny<string>()), Times.AtLeast(6));

        Assert.True(exitCalled, "Exit action was not called.");
    }
}

