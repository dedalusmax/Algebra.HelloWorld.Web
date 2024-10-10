using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.HelloWorld.Web.MvcApp.Models;

[Table("AnimalFoods")]
public class AnimalFood
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    [Required, Length(13, 13)]
    public required string Barcode { get; set; }

    public double Price { get; set; }
}
