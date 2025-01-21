namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class TreeListCommand : ICommand
{
    private readonly IFileSystem _fileSystem;

    private readonly int _depth;

    public TreeListCommand(IFileSystem fileSystem, int depth = 1)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        _depth = depth;
    }

    public void Execute()
    {
        _fileSystem.TreeList(_depth);
    }
}