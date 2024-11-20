using Algebra.HelloWorld.Web.MvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Algebra.HelloWorld.Web.MvcApp.Data;

public class PetShopDbContext : DbContext
{
    public DbSet<PetShop> PetShops { get; set; }

    public DbSet<Pet> Pets { get; set; }

    public DbSet<PetType> PetTypes { get; set; }

    public PetShopDbContext(DbContextOptions<PetShopDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PetShopDB;Trusted_Connection=true;");

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API
        modelBuilder.Entity<PetShop>()
            .HasIndex(x => new { x.Name, x.Address })
            .IsUnique();

        modelBuilder.Entity<Pet>()
            .HasIndex(x => x.Name)
            .IsUnique();

        // TODO: EF Core Configurations

        // SET IDENTITY_INSERT PetShops ON;

        modelBuilder.Entity<PetShop>().HasData(
            new PetShop() { Id = 1, Name = "ASPets", Address = "Zagreb" },
            new PetShop() { Id = 2, Name = "ASPets", Address = "Varaždin" },
            new PetShop() { Id = 3, Name = "ASPets", Address = "Pula" },
            new PetShop() { Id = 4, Name = "ASPets", Address = "Osijek" }
        );

        // SET IDENTITY_INSERT PetType ON;

        modelBuilder.Entity<PetType>().HasData(
            new PetType() { Id = 1, Name = "Pas" },
            new PetType() { Id = 2, Name = "Mačka" },
            new PetType() { Id = 3, Name = "Kornjača" }
        );

        //modelBuilder.Entity<Pet>().HasData(
        //    new Pet() { Id = 1, Name = "", PetShopId = 1, PetTypeId = 1 },
        //    new Pet() { Id = 1, Name = "", PetShopId = 2, PetTypeId = 2 }
        //);

        base.OnModelCreating(modelBuilder);
    }
}
