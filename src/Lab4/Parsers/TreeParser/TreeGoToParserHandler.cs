using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.TreeParser;

public class TreeGoToParserHandler : ParserHandlerBase
{
    private readonly IFileSystem _fileSystem;

    public TreeGoToParserHandler(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override ICommand? Handle(string[] parts)
    {
        if (parts.Length >= 2 && parts[0] == "tree" && parts[1] == "goto")
        {
            if (parts.Length < 3)
            {
                throw new Exception("Expected tree to be goto");
            }

            string path = parts[2];

            return new TreeGoToCommand(_fileSystem, path);
        }

        return base.Handle(parts);
    }
}