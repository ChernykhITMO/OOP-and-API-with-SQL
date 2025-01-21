namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class ConnectCommand : ICommand
{
    private readonly IFileSystem _fileSystem;

    private readonly string _address;

    public ConnectCommand(IFileSystem fileSystem, string address)
    {
        _fileSystem = fileSystem;
        _address = address;
    }

    public void Execute()
    {
        _fileSystem.Connect(_address);
    }
}