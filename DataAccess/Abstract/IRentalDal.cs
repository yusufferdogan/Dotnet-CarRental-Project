using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.DTO;

namespace DataAccess.Abstract;

public interface IRentalDal: IEntityRepository<Rental>
{
    public List<RentalDetailsDto> RentalDetails();
    public bool CheckCarRented(Guid carId);

}