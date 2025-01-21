namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public class DirectoryElement : ITreeElement
{
    public string Path { get; }

    private readonly int _maxDepth;

    private readonly DirectoryTree _tree;

    public DirectoryElement(string path, int maxDepth, DirectoryTree tree)
    {
        Path = path ?? throw new ArgumentNullException(nameof(path));
        _maxDepth = maxDepth;
        _tree = tree ?? throw new ArgumentNullException(nameof(tree));
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitDirectory(this);
    }

    public IEnumerable<ITreeElement> GetChildren()
    {
        var children = new List<ITreeElement>();

        string[] directories = System.IO.Directory.GetDirectories(Path).OrderBy(d => d).ToArray();
        foreach (string directory in directories)
        {
            children.Add(new DirectoryElement(directory, _maxDepth, _tree));
        }

        string[] files = System.IO.Directory.GetFiles(Path).OrderBy(f => f).ToArray();
        foreach (string file in files)
        {
            children.Add(new FileElement(file));
        }

        return children;
    }
}