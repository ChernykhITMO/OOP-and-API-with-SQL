using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.FabricFactory;
using Itmo.ObjectOrientedProgramming.Lab4.InputOutputStrategy;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    private bool _isRunning = true;

    public static void Main(string[] args)
    {
        var inputOutput = new ConsoleInputOutput();
        var fileSystemFactory = new LocalSystemFactory();
        IFileSystem fileSystem = fileSystemFactory.CreateFileSystem();

        var program = new Program();
        var commandParser = new CommandParser(fileSystem, inputOutput, program.Exit);

        program.Run(inputOutput, commandParser);
    }

    public void Run(IInputOutput inputOutput, CommandParser commandParser)
    {
        while (_isRunning)
        {
            try
            {
                inputOutput.WriteLine("> ");
                string input = inputOutput.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                ICommand? command = commandParser.Parse(input);

                if (command != null)
                {
                    if (command is ExitCommand)
                    {
                        _isRunning = false;
                    }

                    command.Execute();
                }
                else
                {
                    inputOutput.WriteLine("Unknown command");
                }
            }
            catch (Exception ex)
            {
                inputOutput.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public void Exit()
    {
        _isRunning = false;
    }
}
