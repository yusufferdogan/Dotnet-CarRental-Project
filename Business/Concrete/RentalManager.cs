using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO;

namespace Business.Concrete;

public class RentalManager: IRentalService
{
    private readonly IRentalDal _rentalDal;
    
    public RentalManager(IRentalDal rentalDal)
    {
        _rentalDal = rentalDal;
    }
    
    public Result Add(Rental rent)
    {
        _rentalDal.Add(rent);
        return new SuccessResult("Rent Successfully Added!");
    }

    public Result Remove(Rental rent)
    {
        _rentalDal.Delete(rent);
        return new SuccessResult("Rent Successfully Deleted!");
    }

    public Result Update(Rental rent)
    {
        _rentalDal.Update(rent);
        return new SuccessResult("Rent Successfully Updated!");
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