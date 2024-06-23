using Core.Entities;

namespace Entities.Concrete;

public class Rental : IEntity
{
    public Guid RentalId { get; set; }
    public Guid CarId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; }
}

