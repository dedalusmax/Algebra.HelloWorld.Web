using System.ComponentModel;

namespace Algebra.HelloWorld.Domain.Models;

public class Author 
{
    public int AuthorId { get; set; }

    [DisplayName("Autor")]
    public string Name { get; set; }

    public string Bio { get; set; }

    public override string ToString() => Name;
}
