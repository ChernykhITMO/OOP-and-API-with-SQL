namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class FileDisplayDriver : IDisplayDriver
{
    private readonly string _filePath;

    public FileDisplayDriver(string filePath)
    {
        _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
    }

    public void Clear() => File.WriteAllText(_filePath, string.Empty);

    public void SetColorText(string color) => File.AppendAllText(_filePath, $"[{color}]\n");

    public void AddText(string text) => File.AppendAllText(_filePath, text + Environment.NewLine);
}