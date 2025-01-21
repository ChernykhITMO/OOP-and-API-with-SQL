namespace Itmo.ObjectOrientedProgramming.Lab4.Operations.FilesOperations;

public interface IFileOperations
{
    void Move(string sourcePath, string destinationPath);

    void Copy(string sourcePath, string destinationPath);

    void Delete(string path);

    void Rename(string path, string newName);

    string ReadFile(string path);

    string GetFileName(string path);
}