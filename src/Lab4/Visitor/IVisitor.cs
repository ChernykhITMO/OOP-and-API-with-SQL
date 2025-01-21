namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public interface IVisitor
{
    void VisitDirectory(DirectoryElement directoryElement);

    void VisitFile(FileElement fileElement);
}