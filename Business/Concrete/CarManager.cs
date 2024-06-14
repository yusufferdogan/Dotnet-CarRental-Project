using System.Data;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CarManager: ICarService
{
    private readonly ICarDal _carDal;

    public CarManager(ICarDal cardal)
    {
        this._carDal = cardal;
    }
    
    public List<Car> GetCarsByBrandId(Guid brandId)
    {
        return _carDal.GetAll(car => car.BrandId == brandId);
    }

    public void Add(Car car)
    {
        if (car.DailyPrice <= 0)
        {
            throw new ConstraintException();
        }

        if (car.Description.Length < 2)
        {
            throw new ConstraintException();
        }
        _carDal.Add(car);
    }

    public void Remove(Car car)
    {
        _carDal.Delete(car);
    }

    public void Update(Car car)
    {
        _carDal.Update(car);
    }

    List<Car> ICarService.GetCarsByColorId(Guid colorId)
    {
        return _carDal.GetAll(car => car.ColorId == colorId);
    }
}