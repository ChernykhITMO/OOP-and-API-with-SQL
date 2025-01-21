namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public class DirectoryTree
{
    public string FileSymbol { get; }

    public string DirectorySymbol { get; }

    public string IndentSymbol { get; }

    public DirectoryTree(string fileSymbol = "📄", string directorySymbol = "📁", string indentSymbol = "|--")
    {
        FileSymbol = fileSymbol;
        DirectorySymbol = directorySymbol;
        IndentSymbol = indentSymbol;
    }
}