using Algebra.HelloWorld.Domain.Interfaces;
using Algebra.HelloWorld.Domain.Models;
using System.Data.Common;

namespace Algebra.HelloWorld.Data.Repositories;

public class BookRepository : IBookRepository
{
    // simulacija baze podataka
    private static List<Book>? _books;

    public BookRepository()
    {
        if (_books == null)
        {
            _books =
            [
                new() { Id = 1, Name = "Lord of the Rings", DateTimeBorrowed = DateTime.Today.AddDays(-3), IsBorrowed = true },
                    new() { Id = 2, Name = "Hobbit", DateTimeBorrowed = DateTime.Today.AddDays(-1) },
                    new() { Id = 3, Name = "Silmarillion", DateTimeBorrowed = DateTime.Today.AddDays(-2) }
            ];
        }
    }

    public void Create(Book book)
    {
        _books!.Add(book);
    }

    public void Edit(Book book)
    {
        var data = _books!.SingleOrDefault(x => x.Id == book.Id);
        if (data != null)
        {
            data.Name = book.Name;
            data.Author = book.Author;
            data.IsBorrowed = book.IsBorrowed;
            data.DateTimeBorrowed = book.DateTimeBorrowed;
        }
    }

    public void Delete(Book book)
    {
        var data = _books!.SingleOrDefault(x => x.Id == book.Id);
        if (data != null)
        {
            _books!.Remove(data);
        }
    }

    public List<Book> GetBooks()
    {
        return _books!;
    }

    public Book? GetById(int id)
    {
        return _books!.SingleOrDefault(x => x.Id == id);
    }
}
