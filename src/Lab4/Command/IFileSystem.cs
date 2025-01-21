namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public interface IFileSystem
{
    void Move(string sourcePath, string destinationPath);

    void Copy(string sourcePath, string destinationPath);

    void Delete(string path);

    void Rename(string path, string newName);

    string ReadFile(string path);

    string GetFullPath(string path);

    string? GetDirectoryName(string path);

    string GetFileName(string path);

    void Connect(string address);

    void Disconnect();

    void TreeGoTo(string path);

    void TreeList(int depth = 1);

    void FileShow(string path, string mode = "console");
}