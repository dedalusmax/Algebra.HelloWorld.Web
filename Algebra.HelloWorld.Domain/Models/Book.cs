using System.ComponentModel;

namespace Algebra.HelloWorld.Domain.Models;

public class Book 
{
    [DisplayName("ID knjige")]
    public int BookId { get; set; }

    [DisplayName("Naslov knjige")]
    public string Title { get; set; }

    [DisplayName("Kratki opis")]
    public string Description { get; set; }

    [DisplayName("Žanr")]
    public string Genre { get; set; }

    [DisplayName("Na zalihi")]
    public int Stock { get; set; }

    [DisplayName("Datum izdanja")]
    public DateTime ReleaseDate { get; set; }

    [DisplayName("Autor")]
    public Author Author { get; set; }

    public override string ToString() => Title;
}
