using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO;

namespace Business.Concrete;

public class RentalManager: IRentalService
{
    private readonly IRentalDal _rentalDal;
    private readonly ICarDal _carDal;
    
    public RentalManager(IRentalDal rentalDal)
    {
        _rentalDal = rentalDal;
    }
    
    public Result RentCar(Guid carId, Guid customerId)
    {
        var car = _carDal.Get(p=>p.CarId == carId);
        if(car == null)
        {
            return new ErrorResult("Car not found!");
        }
        if(_rentalDal.CheckCarRented(carId))
        {
            return new ErrorResult("Car is already rented!");
        }
        var rent = new Rental
        {
            CarId = carId,
            CustomerId = customerId,
            RentDate = DateTime.Now,
            ReturnDate = null
        };
        _rentalDal.Add(rent);
        return new SuccessResult("Car Rented Successfully!");
    }

    public Result ReturnCar(Guid rentId)
    {
        var rent = _rentalDal.Get(p=>p.RentalId == rentId);
        if(rent == null)
        {
            return new ErrorResult("Rent not found!");
        }
        if(rent.ReturnDate != null)
        {
            return new ErrorResult("Car is already returned!");
        }
        rent.ReturnDate = DateTime.Now;
        _rentalDal.Update(rent);
        return new SuccessResult("Car Returned Successfully!");
    }
    
    public DataResult<List<Rental>> GetAll()
    {
        return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
    }

    public DataResult<Rental> GetById(Guid id)
    {
        return new SuccessDataResult<Rental>(_rentalDal.Get(p=>p.RentalId == id));
    }

    public DataResult<RentalDetailsDto> GetRentalDetailsById(Guid id)
    {
        return new SuccessDataResult<RentalDetailsDto>(_rentalDal.RentalDetails().FirstOrDefault(p=> p.RentalId == id));
    }

    public DataResult<List<RentalDetailsDto>> GetAllRentalDetails()
    {
        return new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.RentalDetails());
    }
}