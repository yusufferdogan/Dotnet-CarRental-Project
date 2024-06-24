// See https://aka.ms/new-console-template for more information

using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

class Program
{
    static void Main(string[] args)
    {
        IRentalService rentalService = new RentalManager(new EfRentalDal(), new EfCarDal());
        ICarService carService = new CarManager(new EfCarDal());
        ICustomerService customerService = new CustomerManager(new EfCustomerDal());
        Guid carId = carService.GetCarsDetailsByBrand("Mercedes-Benz").Data[0].CarId;
        Guid customerId = customerService.GetAll().Data.FirstOrDefault(c => c.CompanyName == "Company of Jane").CustomerId;
        // Console.WriteLine(carId);
        // Console.WriteLine(customerId);
        // var result = rentalService.RentCar(carId, customerId);
        Guid rentId = rentalService.GetAll().Data[0].RentalId;
        var result = rentalService.ReturnCar(rentId);
        Console.WriteLine(result.Message);
    }
}