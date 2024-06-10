using Core.Entities;

namespace Entities.Concrete;

public class Car : IEntity
{
    Guid Id { get; set; }
    Guid BrandId { get; set; }
    Guid ColorId { get; set; }
    
    int ModelYear { get; set; }
    decimal DailyPrice { get; set; }
    string Description { get; set; }
}