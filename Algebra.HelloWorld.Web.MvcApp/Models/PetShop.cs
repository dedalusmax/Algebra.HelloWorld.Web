using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.HelloWorld.Web.MvcApp.Models;

[Table("PetShops")]
public class PetShop
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(50)]
    public required string Name { get; set; }

    [Required, StringLength(250)]
    public required string Address { get; set; }

    [EmailAddress]
    public string? EmailAddress { get; set; }

    public virtual ICollection<Pet> Pets { get; set; } = [];

    [NotMapped]
    public int TotalPets => Pets.Count;
}
