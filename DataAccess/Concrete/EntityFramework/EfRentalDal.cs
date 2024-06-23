using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO;

namespace DataAccess.Concrete.EntityFramework;

public class EfRentalDal: EfEntityRepositoryBase<Rental,CarRentalDbContext>, IRentalDal
{
    public List<RentalDetailsDto> RentalDetails()
    {
        throw new NotImplementedException();
    }
}