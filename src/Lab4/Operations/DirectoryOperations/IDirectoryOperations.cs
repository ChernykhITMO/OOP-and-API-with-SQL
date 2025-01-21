namespace Itmo.ObjectOrientedProgramming.Lab4.Operations.DirectoryOperations;

public interface IDirectoryOperations
{
    string GetDirectoryName(string path);

    string GetFullPath(string path);

    void ChangeDirectory(string path);

    IEnumerable<string> ListDirectories(string path);

    IEnumerable<string> ListFiles(string path);
}
