using Algebra.HelloWorld.Domain.Interfaces;
using Algebra.HelloWorld.Web.MvcApp.Models;

namespace Algebra.HelloWorld.Data.Repositories;

public class BookRepository(BookLibraryContext context) : IBookRepository
{
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
        foreach (var book in context.Books)
        {
            Console.WriteLine(book);
        }

        return context.Books.ToList();
    }

    public List<Book> GetBooks(string searchByName)
    {
        return context.Books
            .Where(x => x.Title.StartsWith(searchByName))
            .ToList();
    }

    public Book? GetById(int id)
    {
        // var book = context.Books.FirstOrDefault(x => x.BookId == id);   
        var book = context.Books.Find(id);

        return book;
    }
}
