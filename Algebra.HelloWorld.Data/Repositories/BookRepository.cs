using Algebra.HelloWorld.Domain.Interfaces;
using Algebra.HelloWorld.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

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
        using var connection = new SqlConnection(_connectionString);

        using var command = new SqlCommand($"SELECT * FROM Book", connection);

        connection.Open();

        using var reader = command.ExecuteReader();

        var result = new List<Book>();

        while (reader.Read())
        {
            result.Add(new Book()
            {
                BookId = reader.GetInt32("BookId"),
                //Author = author,
                Title = reader.GetString("Title"),
                Description = reader.GetString("Description"),
                Genre = reader.GetString("Genre"),
                Stock = reader.GetInt32("Stock"),
                ReleaseDate = reader.GetDateTime("ReleaseDate")
            });
        }

        return result;
    }

    public Book? GetById(int id)
    {
        using var connection = new SqlConnection(_connectionString);

        using var command = new SqlCommand($"SELECT * FROM Book WHERE BookId = @id", connection);
        command.Parameters.AddWithValue("@id", id);

        connection.Open();

        using var reader = command.ExecuteReader();

        Book? result = null;

        while (reader.Read())
        {
            result = new Book()
            {
                BookId = reader.GetInt32("BookId"),
                //Author = author,
                Title = reader.GetString("Title"),
                Description = reader.GetString("Description"),
                Genre = reader.GetString("Genre"),
                Stock = reader.GetInt32("Stock"),
                ReleaseDate = reader.GetDateTime("ReleaseDate")
            };
        }

        return result;
     }
}
