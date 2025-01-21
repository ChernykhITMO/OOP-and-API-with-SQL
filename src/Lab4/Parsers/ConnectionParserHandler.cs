using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class ConnectionParserHandler : ParserHandlerBase
{
    private readonly IFileSystem _fileSystem;

    public ConnectionParserHandler(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override ICommand? Handle(string[] parts)
    {
        if (parts[0] == "connect")
        {
            if (parts.Length < 2)
            {
                throw new ArgumentException("Invalid command: connect requires an address.");
            }

            string address = parts[1];
            string mode = "local";

            if (parts.Length >= 4 && parts[2] == "-m")
            {
                mode = parts[3];
            }

            if (mode != "local")
            {
                throw new ArgumentException("Invalid command: connect requires an address.");
            }

            return new ConnectCommand(_fileSystem, address);
        }

        return base.Handle(parts);
    }
}