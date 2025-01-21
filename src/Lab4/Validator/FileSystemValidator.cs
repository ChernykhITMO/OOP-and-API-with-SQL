namespace Itmo.ObjectOrientedProgramming.Lab4.Validator;

public class FileSystemValidator : IValidator
{
    public void CheckPath(string path)
    {
        if (string.IsNullOrWhiteSpace(path) || (!System.IO.File.Exists(path) && !System.IO.Directory.Exists(path)))
        {
            throw new FileNotFoundException($"The file {path} does not exist.");
        }
    }

    public void CheckDirectory(string path)
    {
        if (string.IsNullOrWhiteSpace(path) || (!System.IO.Directory.Exists(path)))
        {
            throw new DirectoryNotFoundException($"The directory {path} does not exist.");
        }
    }

    public void CheckFile(string file)
    {
        if (string.IsNullOrWhiteSpace(file) || !System.IO.File.Exists(file))
        {
            throw new FileNotFoundException($"The file {file} does not exist.");
        }
    }

    public bool IsDirectory(string path)
    {
        return Directory.Exists(path);
    }
}