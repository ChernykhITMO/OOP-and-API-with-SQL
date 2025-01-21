namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class FileRenameCommand : ICommand
{
    private readonly IFileSystem _fileSystem;

    private readonly string _path;

    private readonly string _newName;

    public FileRenameCommand(IFileSystem fileSystem, string path, string newName)
    {
        _fileSystem = fileSystem;
        _path = path;
        _newName = newName;
    }

    public void Execute()
    {
        _fileSystem.Rename(_path, _newName);
    }
}