using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public interface IParserHandler
{
    ICommand? Handle(string[] parts);

    IParserHandler AddNext(IParserHandler handler);
}