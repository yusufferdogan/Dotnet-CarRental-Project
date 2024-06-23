using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO;

namespace DataAccess.Concrete.EntityFramework;

public class EfRentalDal: EfEntityRepositoryBase<Rental,CarRentalDbContext>, IRentalDal
{
    public bool CheckCarRented(Guid carId)
    {
        using (CarRentalDbContext context = new CarRentalDbContext())
        {
            var result = from rental in context.Rentals
                where rental.CarId == carId && rental.ReturnDate == null
                select rental;
            return result.Any();
        }
    }
    public List<RentalDetailsDto> RentalDetails()
    {
        using (CarRentalDbContext context = new CarRentalDbContext())
        {
            {
                var result = from rental in context.Rentals
                    join car in context.Cars on rental.CarId equals car.CarId
                    join cus in context.Customers on rental.CustomerId equals cus.CustomerId
                    join user in context.Users on cus.UserId equals user.UserId
                    join brand in context.Brands on car.BrandId equals brand.BrandId
                    select new RentalDetailsDto
                    {
                        RentalId = rental.RentalId,
                        CarName = car.Description,
                        BrandName = brand.Name,
                        CustomerName = user.FirstName + " " + user.LastName,
                        RentDate = rental.RentDate,
                        ReturnDate = rental.ReturnDate
                    };

                return result.ToList();
            }
                
        }
    }
}