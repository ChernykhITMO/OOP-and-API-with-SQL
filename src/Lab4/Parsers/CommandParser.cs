using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.InputOutputStrategy;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileParser;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.TreeParser;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class CommandParser
{
    private readonly ConnectionParserHandler _handlerChain;

    public CommandParser(IFileSystem fileSystem, IInputOutput inputOutput, Action exitAction)
    {
        _handlerChain = new ConnectionParserHandler(fileSystem);
        _handlerChain
            .AddNext(new DisconnectionParserHandler(fileSystem))
            .AddNext(new TreeGoToParserHandler(fileSystem))
            .AddNext(new TreeListParserHandler(fileSystem))
            .AddNext(new FileMoveParserHandler(fileSystem))
            .AddNext(new FileCopyParserHandler(fileSystem))
            .AddNext(new FileDeleteParserHandler(fileSystem))
            .AddNext(new FileRenameParserHandler(fileSystem))
            .AddNext(new FileShowParserHandler(fileSystem, inputOutput))
            .AddNext(new ExitParserHandler(exitAction));
    }

    public ICommand? Parse(string input)
    {
        string[] parts = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        return _handlerChain.Handle(parts);
    }
}