using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class DisconnectionParserHandler : ParserHandlerBase
{
    private readonly IFileSystem _fileSystem;

    public DisconnectionParserHandler(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override ICommand? Handle(string[] parts)
    {
        if (parts[0] == "disconnect")
        {
            return new DisconnectCommand(_fileSystem);
        }

        return base.Handle(parts);
    }
}
