using Itmo.ObjectOrientedProgramming.Lab4.InputOutputStrategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public class ConsoleVisitor : IVisitor
{
    private readonly IInputOutput _output;
    private readonly DirectoryTree _tree;
    private int _currentDepth = 0;

    public ConsoleVisitor(IInputOutput output, DirectoryTree tree)
    {
        _output = output ?? throw new ArgumentNullException(nameof(output));
        _tree = tree ?? throw new ArgumentNullException(nameof(tree));
    }

    public void VisitDirectory(DirectoryElement directoryElement)
    {
        string indent = string.Concat(Enumerable.Repeat(_tree.IndentSymbol, _currentDepth));
        _output.WriteLine($"{indent}{_tree.DirectorySymbol} {System.IO.Path.GetFileName(directoryElement.Path)}");

        _currentDepth++;
        foreach (ITreeElement child in directoryElement.GetChildren())
        {
            child.Accept(this);
        }

        _currentDepth--;
    }

    public void VisitFile(FileElement fileElement)
    {
        string indent = string.Concat(Enumerable.Repeat(_tree.IndentSymbol, _currentDepth));
        _output.WriteLine($"{indent}{_tree.FileSymbol} {System.IO.Path.GetFileName(fileElement.Path)}");
    }
}