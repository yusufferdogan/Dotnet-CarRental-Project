using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO;

namespace Business.Concrete;

public class CustomerManager: ICustomerService
{
    private readonly ICustomerDal _customerDal;

    public CustomerManager(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }
    
    public Result Add(Customer customer)
    {
        _customerDal.Add(customer);
        return new SuccessResult("Customer added successfully.");
    }

    public Result Remove(Customer customer)
    {
        _customerDal.Delete(customer);
        return new SuccessResult("Customer removed successfully.");
    }

    public Result Update(Customer customer)
    {
        _customerDal.Update(customer);
        return new SuccessResult("Customer updated successfully.");
    }

    public DataResult<List<Customer>> GetAll()
    {
        return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
    }

    public DataResult<Customer> GetById(Guid id)
    {
        return new SuccessDataResult<Customer>(_customerDal.Get(p=>p.CustomerId == id));
    }
    
    public DataResult<List<CustomerDetailDto>> GetAllCustomerDetails()
    {
        return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.CustomerDetails());
    }
}