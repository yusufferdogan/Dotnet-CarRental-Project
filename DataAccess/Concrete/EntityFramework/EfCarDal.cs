using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalDbContext>, ICarDal
{
    public List<Car> Deneme()
    {
        using (CarRentalDbContext context = new CarRentalDbContext())
        {
            var result = from car in context.Cars select car;
            return result.ToList();
        }
    }
    public List<CarDetailDto> GetCarsDetails()
    {
        using (CarRentalDbContext context = new CarRentalDbContext())
        {
            var result = from car in context.Cars
                join brand in context.Brands on car.BrandId equals brand.Id
                join color in context.Colors on car.ColorId equals color.Id
                select new CarDetailDto()
                {
                    CarId = car.Id,
                    BrandName = brand.Name,
                    DailyPrice = car.DailyPrice,
                    ModelYear = car.ModelYear,
                    Description = car.Description,
                    ColorName = color.Name
                };

            return result.ToList();
        }
    }

    public CarDetailDto GetCarDetails(Guid carId)
    {
        using (CarRentalDbContext context = new CarRentalDbContext())
        {
            var result = from car in context.Cars where car.Id == carId
                join brand in context.Brands on car.BrandId equals brand.Id
                join color in context.Colors on car.Id equals color.Id
                select new CarDetailDto()
                {
                    CarId = car.Id,
                    BrandName = brand.Name,
                    DailyPrice = car.DailyPrice,
                    ModelYear = car.ModelYear,
                    Description = car.Description,
                    ColorName = color.Name
                };

            return result.SingleOrDefault();
        }
    }
}