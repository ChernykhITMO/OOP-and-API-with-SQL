using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.FabricFactory;

public interface IFileSystemFactory
{
    IFileSystem CreateFileSystem();
}