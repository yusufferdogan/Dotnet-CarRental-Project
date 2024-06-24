using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO;

namespace DataAccess.Concrete.InMemory;

public class InMemoryCarDal: ICarDal
{
    private List<Car> _cars;
    public InMemoryCarDal()
    {
        _cars = new List<Car>
        {
            new Car { ModelYear = 2015, DailyPrice = 150, Description = "Audi A3" },
            new Car { ModelYear = 2016, DailyPrice = 200, Description = "BMW 3.20" },
            new Car { ModelYear = 2017, DailyPrice = 250, Description = "Mercedes C180" }
        };
    }
    
    public void Add(Car entity)
    {
        _cars.Add(entity);
    }

    public void Delete(Car entity)
    {
        Car carToDelete = _cars.SingleOrDefault(p => p.CarId == entity.CarId);
        _cars.Remove(carToDelete);
    }

    public void Update(Car entity)
    {
        Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == entity.CarId);
        carToUpdate.ModelYear = entity.ModelYear;
        carToUpdate.DailyPrice = entity.DailyPrice;
        carToUpdate.Description = entity.Description;
    }

    public Car Get(Expression<Func<Car, bool>> filter)
    {
        return _cars.Where(filter.Compile()).SingleOrDefault();
    }

    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
    {
        return filter == null ? _cars : _cars.Where(filter.Compile()).ToList();
    }


    public List<CarDetailDto> GetAllCarsDetails()
    {
        throw new NotImplementedException();
    }

    public CarDetailDto GetSingleCarDetails(Guid carId)
    {
        throw new NotImplementedException();
    }

    public List<CarDetailDto> GetCarsDetailsByBrand(string brandName)
    {
        throw new NotImplementedException();
    }

    public List<CarDetailDto> GetCarsDetailsByColor(string colorName)
    {
        throw new NotImplementedException();
    }

    public List<CarDetailDto> GetCarsDetailsByBrandId(Guid brandId)
    {
        throw new NotImplementedException();
    }

    public List<CarDetailDto> GetCarsDetailsByColorId(Guid colorId)
    {
        throw new NotImplementedException();
    }

    public List<CarDetailDto> GetCarDetailsByCarId(Guid carId)
    {
        throw new NotImplementedException();
    }
}