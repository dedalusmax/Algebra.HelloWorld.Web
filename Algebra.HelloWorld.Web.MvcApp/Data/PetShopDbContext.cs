using Algebra.HelloWorld.Web.MvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Algebra.HelloWorld.Web.MvcApp.Data;

public class PetShopDbContext : DbContext
{
    public DbSet<PetShop> PetShops { get; set; }

    public DbSet<Pet> Pets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PetShopDB;Trusted_Connection=true;");

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API

        //modelBuilder.Entity<Pet>()
        //    .HasOne(p => p.PetShop)
        //    .WithMany()
        //    .HasForeignKey(p => p.PetShop)
        //    .IsRequired(true)
        //    .OnDelete(DeleteBehavior.NoAction);

        // TODO: EF Core Configurations

        base.OnModelCreating(modelBuilder);
    }
}
