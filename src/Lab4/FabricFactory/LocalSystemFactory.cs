using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.InputOutputStrategy;
using Itmo.ObjectOrientedProgramming.Lab4.Operations.DirectoryOperations;
using Itmo.ObjectOrientedProgramming.Lab4.Operations.FilesOperations;
using Itmo.ObjectOrientedProgramming.Lab4.Validator;

namespace Itmo.ObjectOrientedProgramming.Lab4.FabricFactory;

public class LocalSystemFactory : IFileSystemFactory
{
    public IFileSystem CreateFileSystem()
    {
        return new LocalFileSystem(
            new ConsoleInputOutput(),
            new FileOperation(),
            new DirectoryOperation(),
            new FileSystemValidator());
    }
}