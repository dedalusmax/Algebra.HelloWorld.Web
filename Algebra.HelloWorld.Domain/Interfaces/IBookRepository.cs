using Algebra.HelloWorld.Domain.Models;

namespace Algebra.HelloWorld.Domain.Interfaces;

public interface IBookRepository
{
    List<Book> GetBooks();

    Book? GetById(int id);

    void Create(Book book);

    void Delete(Book book);
}
