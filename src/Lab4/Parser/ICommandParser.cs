using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public interface ICommandParser
{
    ICommand Parse(string input);
}