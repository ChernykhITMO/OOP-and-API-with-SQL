using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class ExitParserHandler : ParserHandlerBase
{
    private readonly Action _exitAction;

    public ExitParserHandler(Action exitAction)
    {
        _exitAction = exitAction;
    }

    public override ICommand? Handle(string[] parts)
    {
        if (parts[0].Equals("exit", StringComparison.OrdinalIgnoreCase))
        {
            return new ExitCommand(_exitAction);
        }

        return base.Handle(parts);
    }
}