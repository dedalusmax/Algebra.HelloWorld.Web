using Algebra.HelloWorld.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Algebra.HelloWorld.UnitTests;

public class SqlProviderTests
{
    private readonly IConfiguration _configuration;

    public SqlProviderTests()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Testing.json", true);

        _configuration = builder.Build();
    }

    [Fact]
    public void TestSql_Connection_Failed()
    {
        var connection = new SqlConnection(string.Empty);
        
        connection.Open();
        connection.Close();

        // TODO: systemInvalid
        connection.Dispose();
    }

    [Fact]
    public void TestSql_Connection_Success()
    {
        var connection = new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=book_library;Trusted_Connection=true");

        connection.Open();
        connection.Close();

        connection.Dispose();
    }

    [Fact]
    public void TestSql_ConnectionScoped_Success()
    {
        using var connection = new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=book_library;Trusted_Connection=true");

        connection.Open();
    }

    [Fact]
    public void TestSql_ConnectionNewer_Success()
    {
        using var connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=book_library;Trusted_Connection=true;");

        connection.Open();
    }

    [Fact]
    public void TestSql_ConnectionSql_Failed()
    {
        using var connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=book_library;User ID=sa;Password=ratko123;");

        connection.Open();
    }

    [Fact]
    public void TestSql_ConnectionConfiguration_Success()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        using var connection = new SqlConnection(connectionString);

        connection.Open();
    }

    [Fact]
    public void TestSql_NonQueryCommand_Success()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        using var connection = new SqlConnection(connectionString);

        var command = new SqlCommand($"SELECT 1", connection);       

        connection.Open();

        var result = command.ExecuteNonQuery();

        Assert.Equal(-1, result);
    }

    [Fact]
    public void TestSql_ScalarCommand_Success()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        using var connection = new SqlConnection(connectionString);

        using var command = new SqlCommand($"SELECT 1", connection);

        connection.Open();

        var result = command.ExecuteScalar();

        Assert.Equal(1, result);
    }

    [Fact]
    public void TestSql_DataReaderCommand_Success()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        using var connection = new SqlConnection(connectionString);

        using var command = new SqlCommand($"SELECT * FROM Book", connection);

        connection.Open();

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            reader.GetInt32("BookId");

            Console.Write($"BookId: {reader["BookId"]}, ");
            Console.Write($"Title: {reader["Title"]}, ");
            Console.Write($"Genre: {reader["Genre"]}, ");
            Console.Write($"Stock: {reader["Stock"]}, ");
            Console.WriteLine($"ReleaseDate: {reader["ReleaseDate"]}.");
        }
    }


    [Fact]
    public void TestSql_DataReaderCommand_GetAll()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        using var connection = new SqlConnection(connectionString);

        using var command = new SqlCommand($"SELECT * FROM Book", connection);

        connection.Open();

        using var reader = command.ExecuteReader();

        var result = new List<Book>();

        while (reader.Read())
        {
            result.Add(new Book()
            {
                Id = reader.GetInt32("BookId"),
                Name = reader.GetString("Title")
            });
        }

        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal(5, result.Count);
    }

    [Fact]
    public void TestSql_DataReaderCommand_GetById()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        using var connection = new SqlConnection(connectionString);

        using var command = new SqlCommand($"SELECT * FROM Book WHERE BookId = @id", connection);
        command.Parameters.AddWithValue("@id", 3);

        connection.Open();

        using var reader = command.ExecuteReader();

        var result = new List<Book>();

        while (reader.Read())
        {
            result.Add(new Book()
            {
                Id = reader.GetInt32("BookId"),
                Name = reader.GetString("Title")
            });
        }

        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Single(result);
    }
}
