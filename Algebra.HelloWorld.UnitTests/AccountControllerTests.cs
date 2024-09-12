using Algebra.HelloWorld.Web.MvcApp.Controllers;
using Algebra.HelloWorld.Web.MvcApp.Interfaces;
using Algebra.HelloWorld.Web.MvcApp.Models;
using Algebra.HelloWorld.Web.MvcApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

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

    [Fact]
    public void TestController_IndexWithStubRepository_Exception()
    {
        // Arrange
        var stub = new StubAccountRepository();
        var controller = new AccountController(stub);

        // Act
        var result = () => controller.Index();

        // Assert
        Assert.Throws<NotImplementedException>(result);
    }

    [Fact]
    public void TestController_IndexWithFakeRepository_ViewResult()
    {
        // Arrange
        var repository = new FakeAccountRepository();
        var controller = new AccountController(repository);

        // Act
        var result = controller.Index();

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<ViewResult>(result);
    }

    [Fact]
    public void TestController_IndexWithFakeRepository_ModelExists()
    {
        // Arrange
        var repository = new FakeAccountRepository();
        var controller = new AccountController(repository);

        // Act
        var result = controller.Index() as ViewResult;

        // Assert
        Assert.NotNull(result?.Model);
    }

    [Fact]
    public void TestController_IndexWithFakeRepository_ModelIsListOfAccounts()
    {
        // Arrange
        var repository = new FakeAccountRepository();
        var controller = new AccountController(repository);

        // Act
        var result = controller.Index() as ViewResult;

        // Assert
        Assert.IsAssignableFrom<List<Account>>(result?.Model);
    }

    [Fact]
    public void TestController_IndexWithFakeRepository_InitialAccountCount()
    {
        // Arrange
        var repository = new FakeAccountRepository();
        var controller = new AccountController(repository);

        // Act
        var result = controller.Index() as ViewResult;
        var accounts = result?.Model as List<Account>;

        // Assert
        Assert.NotNull(accounts);
        Assert.Equal(3, accounts.Count);
    }

    [Fact]
    public void TestController_IndexWithMockRepository_ViewResult()
    {
        // Arrange 
        var mock = new Mock<IAccountRepository>();
        var controller = new AccountController(mock.Object);

        // Act
        var result = controller.Index();

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<ViewResult>(result);
    }

    [Fact]
    public void TestController_IndexWithMockRepository_ModelExists()
    {
        // Arrange
        var mock = new Mock<IAccountRepository>();
        mock.Setup(repository => repository.GetAccounts())
            .Returns(new List<Account>() );

        var controller = new AccountController(mock.Object);

        // Act
        var result = controller.Index() as ViewResult;

        // Assert
        Assert.NotNull(result?.Model);
    }

    [Fact]
    public void TestController_IndexWithMockRepository_ModelIsListOfAccounts()
    {
        // Arrange
        var mock = new Mock<IAccountRepository>();
        mock.Setup(repository => repository.GetAccounts())
            .Returns(new List<Account>());

        var controller = new AccountController(mock.Object);

        // Act
        var result = controller.Index() as ViewResult;

        // Assert
        Assert.IsAssignableFrom<List<Account>>(result?.Model);
    }

    [Fact]
    public void TestController_IndexWithMockRepository_InitialAccountCount()
    {
        // Arrange
        var mock = new Mock<IAccountRepository>();
        mock.Setup(repository => repository.GetAccounts())
            .Returns(new List<Account>() 
            { 
                new Account() { Id = 1, Name = "Super Banka" },
                new Account() { Id = 2, Name = "Odlična Banka" },
                new Account() { Id = 3, Name = "Najbolja Banka" },
                new Account() { Id = 4, Name = "Loša Banka" }
            });

        var controller = new AccountController(mock.Object);

        // Act
        var result = controller.Index() as ViewResult;
        var accounts = result?.Model as List<Account>;

        // Assert
        Assert.NotNull(accounts);
        Assert.Equal(4, accounts.Count);
    }
}
