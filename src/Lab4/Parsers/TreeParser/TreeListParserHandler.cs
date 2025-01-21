using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.TreeParser;

public class TreeListParserHandler : ParserHandlerBase
{
    private readonly IFileSystem _fileSystem;

    public TreeListParserHandler(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override ICommand? Handle(string[] parts)
    {
        if (parts.Length >= 2 && parts[0] == "tree" && parts[1] == "list")
        {
            int depth = 1;

            for (int i = 2; i < parts.Length; i++)
            {
                if (parts[i] == "-d" && i + 1 < parts.Length)
                {
                    if (!int.TryParse(parts[i + 1], out depth) || depth < 1)
                    {
                        throw new ArgumentException("Invalid depth");
                    }

                    i++;
                }
            }

            return new TreeListCommand(_fileSystem, depth);
        }

        return base.Handle(parts);
    }
}