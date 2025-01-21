namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class TreeGoToCommand : ICommand
{
    private readonly IFileSystem _fileSystem;

    private readonly string _path;

    public TreeGoToCommand(IFileSystem fileSystem, string path)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        _path = path ?? throw new ArgumentNullException(nameof(path));
    }

    public void Execute()
    {
        _fileSystem.TreeGoTo(_path);
    }
}