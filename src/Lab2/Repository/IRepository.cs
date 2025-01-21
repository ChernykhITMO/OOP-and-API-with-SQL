namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public interface IRepository<T>
{
    ResultType<T> Add(T entity);

    public T? FindById(int id);

    IEnumerable<T> GetAll();
}