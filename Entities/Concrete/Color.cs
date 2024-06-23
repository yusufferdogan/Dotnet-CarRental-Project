using Core.Entities;

namespace Entities.Concrete;

public class Color: IEntity
{
    public Guid ColorId { get; set; }
    
    public string Name { get; set; }
}