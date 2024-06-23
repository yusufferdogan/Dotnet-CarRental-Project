using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO;

namespace DataAccess.Concrete.EntityFramework;

public class EfCustomerDal:EfEntityRepositoryBase<Customer, CarRentalDbContext>, ICustomerDal
{
    public List<CustomerDetailDto> CustomerDetails()
    {
        throw new NotImplementedException();
    }
}