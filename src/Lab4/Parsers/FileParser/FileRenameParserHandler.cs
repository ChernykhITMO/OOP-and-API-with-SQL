using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileParser;

public class FileRenameParserHandler : ParserHandlerBase
{
    private readonly IFileSystem _fileSystem;

    public FileRenameParserHandler(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override ICommand? Handle(string[] parts)
    {
        if (parts[0] == "file" && parts[1] == "rename")
        {
            if (parts.Length < 4)
            {
                throw new ArgumentException("Invalid command: rename requires a file path and a new name.");
            }

            string filePath = parts[2];
            string newName = parts[3];
            return new FileRenameCommand(_fileSystem, filePath, newName);
        }

        return base.Handle(parts);
    }
}