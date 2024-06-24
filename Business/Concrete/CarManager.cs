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
    private readonly IColorDal _colorDal;
    private readonly IBrandDal _brandDal;

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

    public DataResult<List<CarDetailDto>> GetAllCarsDetails()
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarsDetails());
    }

    public DataResult<List<CarDetailDto>> GetCarDetailsByCarId(Guid carId)
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByCarId(carId));
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

    public Result Add(CarDetailDto car)
    {
        if (car.DailyPrice <= 0)
        {
            return new ErrorResult(Messages.DailyPriceCannotBeBelowZero);
        }

        if (car.Description.Length < 2)
        {
            return new ErrorResult(Messages.CarDescriptionCannotBeShorterThanCharacters);
        }

        _carDal.Add(new Car()
        {
            ModelYear = car.ModelYear,
            DailyPrice = car.DailyPrice,
            Description = car.Description,
            BrandId = _brandDal.Get(p => p.Name == car.BrandName).BrandId,
            ColorId = _colorDal.Get(p => p.Name == car.ColorName).ColorId
        });
        return new SuccessResult(Messages.CarIsSuccessfullyAdded);
    }

    public Result Remove(Car car)
    {
        _carDal.Delete(car);
        return new SuccessResult(Messages.CarIsSuccessfullyRemoved);
    }

    public Result Update(CarDetailDto car)
    {
        if (car.DailyPrice <= 0)
        {
            return new ErrorResult(Messages.DailyPriceCannotBeBelowZero);
        }

        if (car.Description.Length < 2)
        {
            return new ErrorResult(Messages.CarDescriptionCannotBeShorterThanCharacters);
        }

        var brand = _brandDal.Get(p => p.Name == car.BrandName);
        if (brand == null)
        {
            return new ErrorResult("Brand not found");
        }

        var color = _colorDal.Get(p => p.Name == car.ColorName);
        if (color == null)
        {
            return new ErrorResult("Color not found");
        }

        var carEntity = _carDal.Get(p => p.CarId == car.CarId);

        if (carEntity == null)
        {
            // Create a new car if it doesn't exist
            carEntity = new Car
            {
                CarId = car.CarId,
                ModelYear = car.ModelYear,
                DailyPrice = car.DailyPrice,
                Description = car.Description,
                BrandId = brand.BrandId,
                ColorId = color.ColorId
            };
            _carDal.Add(carEntity);
            return new SuccessResult(Messages.CarIsSuccessfullyAdded);
        }
        else
        {
            // Update the existing car
            carEntity.ModelYear = car.ModelYear;
            carEntity.DailyPrice = car.DailyPrice;
            carEntity.Description = car.Description;
            carEntity.BrandId = brand.BrandId;
            carEntity.ColorId = color.ColorId;
            _carDal.Update(carEntity);
            return new SuccessResult(Messages.CarIsSuccessfullyUpdated);
        }
    }

    public DataResult<Car> GetById(Guid id)
    {
        return new SuccessDataResult<Car>(_carDal.Get(car => car.CarId == id));
    }

    public Result RemoveById(Guid id)
    {
        _carDal.Delete(_carDal.Get(car => car.CarId == id));
        return new SuccessResult(Messages.CarIsSuccessfullyRemoved);
    }
}