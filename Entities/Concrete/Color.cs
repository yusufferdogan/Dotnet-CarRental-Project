using Core.Entities;

namespace Entities.Concrete;

public class Color: IEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
}