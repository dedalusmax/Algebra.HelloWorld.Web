using Algebra.HelloWorld.Domain.Interfaces;
using Algebra.HelloWorld.Domain.Models;

namespace Algebra.HelloWorld.Data.Repositories;

public class BookRepository : IBookRepository
{
    private readonly string _connectionString = string.Empty;

    public BookRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public void Create(Book book)
    {
        //_books!.Add(book);
    }

    public void Update(Book book)
    {
        //var data = _books!.SingleOrDefault(x => x.Id == book.Id);
        //if (data != null)
        //{
        //    data.Name = book.Name;
        //    data.Author = book.Author;
        //    data.IsBorrowed = book.IsBorrowed;
        //    data.DateTimeBorrowed = book.DateTimeBorrowed;
        //}
    }

    public void Delete(Book book)
    {
        //var data = _books!.SingleOrDefault(x => x.Id == book.Id);
        //if (data != null)
        //{
        //    _books!.Remove(data);
        //}
    }

    public List<Book> GetBooks()
    {
        return new List<Book>();
    }

    public Book? GetById(int id)
    {
        return new Book();
    }
}
