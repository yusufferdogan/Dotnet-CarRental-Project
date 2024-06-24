using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.DTO;

namespace DataAccess.Abstract;

public interface ICarDal : IEntityRepository<Car>
{
    List<CarDetailDto> GetAllCarsDetails();

    CarDetailDto GetSingleCarDetails(Guid carId);

    public List<CarDetailDto> GetCarsDetailsByBrand(string brandName);

    public List<CarDetailDto> GetCarsDetailsByColor(string colorName);

    public List<CarDetailDto> GetCarsDetailsByBrandId(Guid brandId);

    public List<CarDetailDto> GetCarsDetailsByColorId(Guid colorId);

    List<CarDetailDto> GetCarDetailsByCarId(Guid carId);
}