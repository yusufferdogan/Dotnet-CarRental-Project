using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.DTO;

namespace DataAccess.Abstract;

public interface ICarDal : IEntityRepository<Car>
{
    List<CarDetailDto> GetCarsDetails();

    CarDetailDto GetCarDetails(Guid carId);
}