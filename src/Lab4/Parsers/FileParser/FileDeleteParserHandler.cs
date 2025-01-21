using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileParser;

public class FileDeleteParserHandler : ParserHandlerBase
{
    private readonly IFileSystem _fileSystem;

    public FileDeleteParserHandler(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override ICommand? Handle(string[] parts)
    {
        if (parts[0] == "file" && parts[1] == "delete")
        {
            if (parts.Length < 3)
            {
                throw new ArgumentException("Invalid command: delete requires a file path.");
            }

            string filePath = parts[2];
            return new FileDeleteCommand(_fileSystem, filePath);
        }

        return base.Handle(parts);
    }
}
