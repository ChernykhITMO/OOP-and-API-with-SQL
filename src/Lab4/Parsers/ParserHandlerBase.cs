using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class ParserHandlerBase : IParserHandler
{
    private IParserHandler? _nextHandler;

    public IParserHandler AddNext(IParserHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual ICommand? Handle(string[] parts)
    {
        if (_nextHandler != null)
        {
            return _nextHandler.Handle(parts);
        }

        throw new ArgumentException($"Unknown command: {parts[0]}");
    }
}