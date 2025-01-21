namespace Itmo.ObjectOrientedProgramming.Lab4.Operations.DirectoryOperations;

public class DirectoryOperation : IDirectoryOperations
{
    public string GetDirectoryName(string path)
    {
        return Path.GetDirectoryName(path) ?? throw new InvalidOperationException();
    }

    public string GetFullPath(string path)
    {
        return Path.GetFullPath(path);
    }

    public void ChangeDirectory(string path)
    {
        if (!Exists(path))
        {
            throw new DirectoryNotFoundException($"Directory '{path}' not found.");
        }

        System.IO.Directory.SetCurrentDirectory(path);
    }

    public bool Exists(string path)
    {
        return System.IO.Directory.Exists(path);
    }

    public IEnumerable<string> ListDirectories(string path)
    {
        if (!Exists(path))
        {
            throw new DirectoryNotFoundException($"Directory '{path}' not found.");
        }

        return System.IO.Directory.GetDirectories(path);
    }

    public IEnumerable<string> ListFiles(string path)
    {
        if (!Exists(path))
        {
            throw new DirectoryNotFoundException($"Directory '{path}' not found.");
        }

        return System.IO.Directory.GetFiles(path);
    }
}