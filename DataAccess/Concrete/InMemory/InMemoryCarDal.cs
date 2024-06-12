using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;

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
        Car carToDelete = _cars.SingleOrDefault(p => p.Id == entity.Id);
        _cars.Remove(carToDelete);
    }

    public void Update(Car entity)
    {
        Car carToUpdate = _cars.SingleOrDefault(c => c.Id == entity.Id);
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
}