namespace Algebra.HelloWorld.Domain.Interfaces;

public interface IGenericRepository<T>
    where T : class, IEntity
{
    List<T> GetBooks();

    T? GetById(int id);

    void Create(T entity);

    void Delete(T entity);
}
