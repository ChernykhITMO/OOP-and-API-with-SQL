using Itmo.ObjectOrientedProgramming.Lab4.InputOutputStrategy;
using Itmo.ObjectOrientedProgramming.Lab4.Operations.DirectoryOperations;
using Itmo.ObjectOrientedProgramming.Lab4.Operations.FilesOperations;
using Itmo.ObjectOrientedProgramming.Lab4.Validator;
using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class LocalFileSystem : IFileSystem
{
    private readonly IInputOutput _output;

    private readonly IFileOperations _fileOperations;

    private readonly IDirectoryOperations _directoryOperations;

    private readonly IValidator _validator;

    private bool _isConnected = false;

    private string? _currentDirectory;

    public LocalFileSystem(IInputOutput output, IFileOperations fileOperations, IDirectoryOperations directoryOperations, IValidator validator)
    {
        _output = output ?? throw new ArgumentNullException(nameof(output));
        _fileOperations = fileOperations ?? throw new ArgumentNullException(nameof(fileOperations));
        _directoryOperations = directoryOperations ?? throw new ArgumentNullException(nameof(directoryOperations));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public void Move(string sourcePath, string destinationPath)
    {
        _validator.CheckPath(sourcePath);
        if (_validator.IsDirectory(destinationPath))
        {
            string fileName = Path.GetFileName(sourcePath);
            destinationPath = Path.Combine(destinationPath, fileName);
        }

        _fileOperations.Move(sourcePath, destinationPath);
    }

    public void Copy(string sourcePath, string destinationPath)
    {
        _validator.CheckPath(sourcePath);

        if (Directory.Exists(destinationPath))
        {
            string fileName = Path.GetFileName(sourcePath);
            destinationPath = Path.Combine(destinationPath, fileName);
        }

        _fileOperations.Copy(sourcePath, destinationPath);
    }

    public void Delete(string path)
    {
        _validator.CheckPath(path);
        _fileOperations.Delete(path);
    }

    public string ReadFile(string path)
    {
        _validator.CheckFile(path);
        return _fileOperations.ReadFile(path);
    }

    public void Rename(string? path, string newName)
    {
        if (path != null)
        {
            _validator.CheckPath(path);
            _fileOperations.Rename(path, newName);
        }
    }

    public string GetFileName(string path)
    {
        return _fileOperations.GetFileName(path);
    }

    public void Connect(string address)
    {
        if (_isConnected)
        {
            throw new InvalidOperationException("Already connected.");
        }

        if (string.IsNullOrWhiteSpace(address))
        {
            throw new ArgumentException("Address cannot be null or empty.");
        }

        string targetPath = Path.IsPathRooted(address)
            ? address
            : Path.Combine(Directory.GetCurrentDirectory(), address);

        if (!Directory.Exists(targetPath))
        {
            throw new DirectoryNotFoundException($"The directory '{targetPath}' does not exist.");
        }

        Directory.SetCurrentDirectory(targetPath);

        _isConnected = true;
        _currentDirectory = targetPath;
        _output.WriteLine($"Connected to {targetPath}");
    }

    public void Disconnect()
    {
        if (!_isConnected)
        {
            throw new InvalidOperationException("Not connected.");
        }

        _isConnected = false;
        _currentDirectory = null;
        _output.WriteLine("Disconnected.");
    }

    public string GetDirectoryName(string path)
    {
        return _directoryOperations.GetDirectoryName(path);
    }

    public string GetFullPath(string path)
    {
        return _directoryOperations.GetFullPath(path);
    }

    public void TreeList(int depth = 1)
    {
        if (!_isConnected)
            throw new InvalidOperationException("Not connected.");

        var directoryTree = new DirectoryTree();

        var visitor = new ConsoleVisitor(_output, directoryTree);

        var rootDirectory = new DirectoryElement(
            _currentDirectory ?? Directory.GetCurrentDirectory(),
            depth,
            directoryTree);
        rootDirectory.Accept(visitor);
        _output.WriteLine($"Tree listed with depth -{depth}");
    }

    public void TreeGoTo(string path)
    {
        if (!_isConnected)
            throw new InvalidOperationException("Not connected.");

        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("Path cannot be null or empty.");

        string targetPath = Path.IsPathRooted(path)
            ? path
            : Path.Combine(_currentDirectory ?? Directory.GetCurrentDirectory(), path);

        if (!Directory.Exists(targetPath))
            throw new DirectoryNotFoundException($"The directory '{targetPath}' does not exist.");

        Directory.SetCurrentDirectory(targetPath);
        _currentDirectory = targetPath;

        _output.WriteLine($"Changed directory to {targetPath}");
    }

    public void FileShow(string path, string mode = "console")
    {
        if (!_isConnected)
            throw new InvalidOperationException("Not connected.");

        string content = _fileOperations.ReadFile(path);
        _output.WriteLine(content);
    }
}