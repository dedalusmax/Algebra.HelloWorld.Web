using Algebra.HelloWorld.Web.MvcApp.Controllers;

namespace Algebra.HelloWorld.UnitTests;

public class BookControllerTests
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var controller = new BookController();

        // Act
        controller.Index();

        // Assert
    }
}