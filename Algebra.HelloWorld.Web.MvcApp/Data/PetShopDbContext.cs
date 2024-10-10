using Algebra.HelloWorld.Web.MvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Algebra.HelloWorld.Web.MvcApp.Data;

public class PetShopDbContext : DbContext
{
    public DbSet<PetShop> PetShops { get; set; }

    public DbSet<Pet> Pets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TODO: Fluent API

        // TODO: EF Core Configurations

        base.OnModelCreating(modelBuilder);
    }
}
