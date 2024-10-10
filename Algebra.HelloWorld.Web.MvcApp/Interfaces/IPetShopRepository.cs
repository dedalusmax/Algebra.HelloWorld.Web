using Algebra.HelloWorld.Web.MvcApp.Models;

namespace Algebra.HelloWorld.Web.MvcApp.Interfaces;

public interface IPetShopRepository
{
    List<PetShop> GetAll();
}
