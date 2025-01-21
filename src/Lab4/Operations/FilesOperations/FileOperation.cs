namespace Itmo.ObjectOrientedProgramming.Lab4.Operations.FilesOperations;

public class FileOperation : IFileOperations
{
    public void Move(string sourcePath, string destinationPath)
    {
        File.Move(sourcePath, destinationPath);
    }

    public void Copy(string sourcePath, string destinationPath)
    {
        File.Copy(sourcePath, destinationPath);
    }

    public void Delete(string path)
    {
        File.Delete(path);
    }

    public void Rename(string path, string newName)
    {
        string directory = Path.GetDirectoryName(path) ?? throw new InvalidOperationException();
        string newPath = Path.Combine(directory, newName);
        File.Move(path, newPath);
    }

    public string ReadFile(string path)
    {
        return File.ReadAllText(path);
    }

    public string GetFileName(string path)
    {
        return Path.GetFileName(path);
    }
}