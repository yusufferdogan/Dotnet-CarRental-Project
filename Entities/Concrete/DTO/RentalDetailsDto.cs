using Core.Entities;

namespace Entities.Concrete.DTO;

public class RentalDetailsDto:IDto
{
    public Guid RentalId { get; set; }
    public string CarName { get; set; }
    public string BrandName { get; set; }
    public string CustomerName { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime? ReturnDate { get; set; } = null;
}