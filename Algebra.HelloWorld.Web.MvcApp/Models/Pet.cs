using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.HelloWorld.Web.MvcApp.Models;

[Table("Pets")]
public class Pet
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public string? Description { get; set; }

    public byte PetType { get; set; }

    //[ForeignKey("PetShopId"), Column("PetShopId")]
    //public int PetShop { get; set; }

    //[Column("PetShop")]
    //public int PetShop { get; set; }

    [Required]
    public virtual required PetShop PetShop { get; set; }

    //[ConcurrencyCheck]
    //public string Version { get; set; }

    //[Timestamp]
    //public byte[] DateTimeStamp { get; set; }
}
