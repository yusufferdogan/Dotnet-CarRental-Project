using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTO;

namespace Business.Abstract;

public interface ICustomerService
{
    public Result Add(Customer customer);
    public Result Remove(Customer customer);
    public Result Update(Customer customer);
    public DataResult<List<Customer>> GetAll();
    public DataResult<Customer> GetById(Guid id);
    public DataResult<List<CustomerDetailDto>> GetAllCustomerDetails();
    public Result RemoveById(Guid id);
}