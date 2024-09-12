using Algebra.HelloWorld.Web.MvcApp.Controllers;
using Algebra.HelloWorld.Web.MvcApp.Models;
using Algebra.HelloWorld.Web.MvcApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Algebra.HelloWorld.UnitTests;

public class AccountControllerTests
{
    [Fact]
    public void TestController_Ctor_ArgumentNullException()
    {
        // Arrange & act
        var result = () => new AccountController(null);

        // Assert
        Assert.Throws<ArgumentNullException>(result);
    }

    //[Fact]
    //public void TestController_IndexNoData_NullReferenceException()
    //{
    //    // Arrange
    //    var controller = new AccountController(null);

    //    // Act
    //    var result = () => controller.Index();

    //    // Assert
    //    Assert.Throws<NullReferenceException>(result);
    //}

    [Fact]
    public void TestController_IndexWithRepository_ViewResult()
    {
        // Arrange
        var repository = new AccountRepository();
        var controller = new AccountController(repository);

        // Act
        var result = controller.Index();

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<ViewResult>(result);
    }

    [Fact]
    public void TestController_IndexWithRepository_ModelExists()
    {
        // Arrange
        var repository = new AccountRepository();
        var controller = new AccountController(repository);

        // Act
        var result = controller.Index() as ViewResult;

        // Assert
        Assert.NotNull(result?.Model);
    }

    [Fact]
    public void TestController_IndexWithRepository_ModelIsListOfAccounts()
    {
        // Arrange
        var repository = new AccountRepository();
        var controller = new AccountController(repository);

        // Act
        var result = controller.Index() as ViewResult;

        // Assert
        Assert.IsAssignableFrom<List<Account>>(result?.Model);
    }

    [Fact]
    public void TestController_IndexWithRepository_InitialAccountCount()
    {
        // Arrange
        var repository = new AccountRepository();
        var controller = new AccountController(repository);

        // Act
        var result = controller.Index() as ViewResult;
        var accounts = result?.Model as List<Account>;

        // Assert
        Assert.NotNull(accounts);
        Assert.Equal(3, accounts.Count);
    }
}
