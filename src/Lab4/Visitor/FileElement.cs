namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public class FileElement : ITreeElement
{
    public string Path { get; }

    public FileElement(string path)
    {
        Path = path ?? throw new ArgumentNullException(nameof(path));
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitFile(this);
    }
}