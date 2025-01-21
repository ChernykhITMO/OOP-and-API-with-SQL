namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class ExitCommand : ICommand
{
    private readonly Action _exitAction;

    public ExitCommand(Action exitAction)
    {
        _exitAction = exitAction;
    }

    public void Execute()
    {
        _exitAction();
    }
}