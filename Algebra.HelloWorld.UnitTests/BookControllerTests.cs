using Algebra.HelloWorld.Data.Repositories;
using Algebra.HelloWorld.Web.MvcApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Algebra.HelloWorld.UnitTests;

public class BookControllerTests
{
    [Fact]
    public void TestBookController_Index_Valid()
    {
        // Arrange
        var repository = new BookRepository();
        var controller = new BookController(repository);

        // Act
        var result = controller.Index();

        // Assert
        Assert.IsAssignableFrom<ViewResult>(result);
        Assert.NotNull(result);
    }
}