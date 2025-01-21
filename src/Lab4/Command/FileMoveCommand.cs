namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class FileMoveCommand : ICommand
{
    private readonly IFileSystem _fileSystem;

    private readonly string _sourcePath;

    private readonly string _destinationPath;

    public FileMoveCommand(IFileSystem fileSystem, string sourcePath, string destinationPath)
    {
        _fileSystem = fileSystem;
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public void Execute()
    {
        _fileSystem.Move(_sourcePath, _destinationPath);
    }
}