using Algebra.HelloWorld.Domain.Interfaces;
using System.ComponentModel;

namespace Algebra.HelloWorld.Domain.Models;

public class Author : IEntity
{
    public int Id { get; set; }

    [DisplayName("Autor knjige")]
    public string Name { get; set; }
}
