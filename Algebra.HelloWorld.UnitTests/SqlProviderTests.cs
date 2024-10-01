using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

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
}
