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
        Guid carId = Guid.Parse("a730c85b-dc0a-417f-8f2a-06912b8de354"); //carService.GetCarsDetailsByBrand("Mercedes-Benz").Data[0].CarId;
        Guid customerId = Guid.Parse("a6f3c706-51af-4128-a4f5-0cf80e6c94dc"); // customerService.GetAll().Data.FirstOrDefault(c => c.CompanyName == "Company of Jane")
        // .CustomerId;
        // Console.WriteLine(carId);
        // Console.WriteLine(customerId);
        // var result = rentalService.RentCar(carId, customerId);
        Guid rentId = rentalService.GetAll().Data[0].RentalId;
        var result = rentalService.ReturnCar(rentId);
        Console.WriteLine(result.Message);
    }
}