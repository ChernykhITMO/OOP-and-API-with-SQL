namespace Itmo.ObjectOrientedProgramming.Lab4.Validator;

public interface IValidator
{
    void CheckPath(string path);

    void CheckDirectory(string path);

    void CheckFile(string file);

    bool IsDirectory(string path);
}