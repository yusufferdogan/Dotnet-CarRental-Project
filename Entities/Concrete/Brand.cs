using Core.Entities;

namespace Entities.Concrete;

public class Brand : IEntity
{
    public Guid BrandId { get; set; }
    
    public string Name { get; set; }

}