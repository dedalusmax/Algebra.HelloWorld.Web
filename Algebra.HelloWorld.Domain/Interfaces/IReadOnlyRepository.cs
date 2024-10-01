namespace Algebra.HelloWorld.Domain.Interfaces;

internal interface IReadOnlyRepository<T>
{
    List<T> GetAll();
}
