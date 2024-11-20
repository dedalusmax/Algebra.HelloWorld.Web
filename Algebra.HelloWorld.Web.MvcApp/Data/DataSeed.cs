using Algebra.HelloWorld.Web.MvcApp.Models;

namespace Algebra.HelloWorld.Web.MvcApp.Data;

public class DataSeed(PetShopDbContext context)
{
    public void Run()
    {
        if (!context.Pets.Any())
        {
            context.Pets.Add(new Pet() { Name = "Pas 1", Description = string.Empty, PetShopId = 1, PetTypeId = 1 });
            context.SaveChanges();
        }
    }
}
