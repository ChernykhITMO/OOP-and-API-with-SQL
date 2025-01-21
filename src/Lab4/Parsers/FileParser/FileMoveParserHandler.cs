using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileParser;

public class FileMoveParserHandler : ParserHandlerBase
{
    private readonly IFileSystem _fileSystem;

    public FileMoveParserHandler(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override ICommand? Handle(string[] parts)
    {
        if (parts[0] == "file" && parts[1] == "move")
        {
            if (parts.Length < 4)
            {
                throw new ArgumentException("Invalid command: move requires source and destination paths.");
            }

            string source = parts[2];
            string destination = parts[3];
            return new FileMoveCommand(_fileSystem, source, destination);
        }

        return base.Handle(parts);
    }
}
