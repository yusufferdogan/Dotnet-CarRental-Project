using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO;

namespace DataAccess.Concrete.EntityFramework;

public class EfCustomerDal:EfEntityRepositoryBase<Customer, CarRentalDbContext>, ICustomerDal
{
    public List<CustomerDetailDto> CustomerDetails()
    {
        using (CarRentalDbContext context = new CarRentalDbContext())
        {
            var result = from customer in context.Customers
                join user in context.Users on customer.UserId equals user.UserId
                select new CustomerDetailDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    CompanyName = customer.CompanyName
                };

            return result.ToList();
        }
    }
}