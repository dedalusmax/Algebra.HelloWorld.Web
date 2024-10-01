using Algebra.HelloWorld.Domain.Interfaces;

namespace Algebra.HelloWorld.Domain.Models;

public class Genre : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }
}
