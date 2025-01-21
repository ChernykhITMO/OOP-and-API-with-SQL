namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IUpdater<T>
{
    ResultType<T> Update(T entity, User author);
}