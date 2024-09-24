using Algebra.HelloWorld.Domain.Interfaces;

namespace Algebra.HelloWorld.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T>
    where T : class, IEntity
{
    private static List<T> _entities;

    public void Create(T entity)
    {
        _entities.Add(entity);
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public List<T> GetBooks()
    {
        return _entities;   
    }

    public T? GetById(int id)
    {
        return _entities.SingleOrDefault(x => x.Id == id);
    }
}
