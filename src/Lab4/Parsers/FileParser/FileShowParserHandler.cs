using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.InputOutputStrategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileParser;

public class FileShowParserHandler : ParserHandlerBase
{
    private readonly IFileSystem _fileSystem;

    private readonly IInputOutput _inputOutput;

    public FileShowParserHandler(IFileSystem fileSystem, IInputOutput inputOutput)
    {
        _inputOutput = inputOutput;
        _fileSystem = fileSystem;
    }

    public override ICommand? Handle(string[] parts)
    {
        if (parts.Length >= 2 && parts[0] == "file" && parts[1] == "show")
        {
            if (parts.Length < 3)
            {
                throw new ArgumentException("Show file format is invalid.");
            }

            string path = parts[2];
            string mode = "console";

            for (int i = 3; i < parts.Length; i++)
            {
                if (parts[i] == "-m" && i + 1 < parts.Length)
                {
                    mode = parts[i + 1];
                    i++;
                }
            }

            if (mode != "console")
            {
                throw new ArgumentException("Unsupported mode. Only 'console' mode is supported.");
            }

            return new FileShowCommand(_fileSystem, path, _inputOutput);
        }

        return base.Handle(parts);
    }
}