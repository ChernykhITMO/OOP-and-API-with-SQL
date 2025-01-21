using Itmo.ObjectOrientedProgramming.Lab4.InputOutputStrategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class FileShowCommand : ICommand
{
    private readonly IFileSystem _fileSystem;

    private readonly string _path;

    private readonly IInputOutput _inputOutput;

    public FileShowCommand(IFileSystem fileSystem, string path, IInputOutput inputOutput)
    {
        _inputOutput = inputOutput;
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        _path = path ?? throw new ArgumentNullException(nameof(path));
    }

    public void Execute()
    {
        string content = _fileSystem.ReadFile(_path);
        _inputOutput.WriteLine(content);
    }
}