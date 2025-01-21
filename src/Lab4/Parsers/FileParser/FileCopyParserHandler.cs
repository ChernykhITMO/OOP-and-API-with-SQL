using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileParser;

public class FileCopyParserHandler : ParserHandlerBase
{
    private readonly IFileSystem _fileSystem;

    public FileCopyParserHandler(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override ICommand? Handle(string[] parts)
    {
        if (parts[0] == "file" && parts[1] == "copy")
        {
            if (parts.Length < 4)
            {
                throw new ArgumentException("Invalid command: copy requires source and destination paths.");
            }

            string source = parts[2];
            string destination = parts[3];
            return new FileCopyCommand(_fileSystem, source, destination);
        }

        return base.Handle(parts);
    }
}