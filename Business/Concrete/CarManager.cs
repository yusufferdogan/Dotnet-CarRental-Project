using System.Data;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO;

namespace Business.Concrete;

public class CarManager : ICarService
{
    private readonly ICarDal _carDal;

    public CarManager(ICarDal cardal)
    {
        this._carDal = cardal;
    }
    
    public DataResult<List<CarDetailDto>> GetCarsDetailsByBrandId(Guid brandId)
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetailsByBrandId(brandId));
    }

    public DataResult<List<CarDetailDto>> GetCarsDetailsByColorId(Guid colorId)
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetailsByColorId(colorId));
    }
    
    public DataResult<List<CarDetailDto>> GetAllCarsDetails(Guid brandId)
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarsDetails());
    }

    public DataResult<List<CarDetailDto>> GetCarsDetailsByBrand(string brand)
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetailsByBrand(brand));
    }

    public DataResult<List<CarDetailDto>> GetCarsDetailsByColor(string color)
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetailsByColor(color));
    }

    public DataResult<List<Car>> GetCarsByColorId(Guid colorId)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(car => car.ColorId == colorId));
    }
    
    public DataResult<List<Car>> GetCarsByBrandId(Guid brandId)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(car => car.BrandId == brandId));
    }

    public Result Add(Car car)
    {
        if (car.DailyPrice <= 0)
        {
            return new ErrorResult(Messages.DailyPriceCannotBeBelowZero);
        }

        if (car.Description.Length < 2)
        {

            return new ErrorResult(Messages.CarDescriptionCannotBeShorterThanCharacters);
        }

        _carDal.Add(car);
        return new SuccessResult(Messages.CarIsSuccessfullyAdded);
    }

    public Result Remove(Car car)
    {
        _carDal.Delete(car);
        return new SuccessResult(Messages.CarIsSuccessfullyRemoved);

    }

    public Result Update(Car car)
    {
        _carDal.Update(car);
        return new SuccessResult(Messages.CarIsSuccessfullyUpdated);
    }

}