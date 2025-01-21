namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public interface ITreeElement
{
    void Accept(IVisitor visitor);
}