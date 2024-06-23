using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTO;

namespace Business.Abstract;

public interface IRentalService
{
    public Result RentCar(Guid carId, Guid customerId);
    public Result ReturnCar(Guid rentId);
    public DataResult<List<Rental>> GetAll();
    public DataResult<Rental> GetById(Guid id);
    public DataResult<RentalDetailsDto> GetRentalDetailsById(Guid id);
    public DataResult<List<RentalDetailsDto>> GetAllRentalDetails();
}