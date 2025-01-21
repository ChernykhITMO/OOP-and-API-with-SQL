namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly List<T> _entities = new List<T>();

    public ResultType<T> Add(T entity)
    {
        foreach (T ent in _entities)
        {
            if (ent.Id == entity.Id)
            {
                return new ResultType<T>(null, false, "Entity already has an assigned ID");
            }
        }

        _entities.Add(entity);

        return new ResultType<T>(entity, true, string.Empty);
    }

    public T? FindById(int id)
    {
        return _entities.FirstOrDefault(entity => entity.Id == id);
    }

    public IEnumerable<T> GetAll()
    {
        return _entities;
    }
}