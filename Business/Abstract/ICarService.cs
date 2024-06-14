using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO;

namespace Business.Abstract;

public interface ICarService
{
    public DataResult<List<Car>> GetCarsByColorId(Guid colorId);

    public DataResult<List<Car>> GetCarsByBrandId(Guid brandId);

    public DataResult<List<CarDetailDto>> GetAllCarsDetails(Guid brandId);
    public DataResult<List<CarDetailDto>> GetCarsDetailsByBrand(string brand);
    public DataResult<List<CarDetailDto>> GetCarsDetailsByColor(string color);
    
    public DataResult<List<CarDetailDto>> GetCarsDetailsByBrandId(Guid brandId);
    public DataResult<List<CarDetailDto>> GetCarsDetailsByColorId(Guid colorId);

    public Result Add(Car car);

    public Result Remove(Car car);

    public Result Update(Car car);
    
}