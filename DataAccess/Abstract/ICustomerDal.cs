using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.DTO;

namespace DataAccess.Abstract;

public interface ICustomerDal:IEntityRepository<Customer>
{
    public List<CustomerDetailDto> CustomerDetails();

}