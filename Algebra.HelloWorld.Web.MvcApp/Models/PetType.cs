using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.HelloWorld.Web.MvcApp.Models;

[Table("PetTypes")]
public class PetType
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }
}
