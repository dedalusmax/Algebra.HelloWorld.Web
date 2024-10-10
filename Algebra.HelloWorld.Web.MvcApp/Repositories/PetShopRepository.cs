using Algebra.HelloWorld.Web.MvcApp.Data;
using Algebra.HelloWorld.Web.MvcApp.Interfaces;
using Algebra.HelloWorld.Web.MvcApp.Models;

namespace Algebra.HelloWorld.Web.MvcApp.Repositories;

public class PetShopRepository(PetShopDbContext context) : IPetShopRepository
{
    public List<PetShop> GetAll()
    {
        return context.PetShops.ToList();
    }
}
