using Core.Entities;

namespace Entities.Concrete;

public class Customer : IEntity
{
    public Guid CustomerId { get; set; }
    public Guid UserId { get; set; }
    public string? CompanyName { get; set; }
}