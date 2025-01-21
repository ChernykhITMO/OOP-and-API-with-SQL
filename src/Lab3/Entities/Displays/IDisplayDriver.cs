namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public interface IDisplayDriver
{
    void Clear();

    void SetColorText(string color);

    void AddText(string text);
}