using Core.Entities;

namespace Entities.Concrete;

public class Brand : IEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

}