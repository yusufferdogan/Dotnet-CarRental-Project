// See https://aka.ms/new-console-template for more information

using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

class Program
{
    static void Main(string[] args)
    {
        ICarService carService = new CarManager(new EfCarDal());
        var cars = carService.GetCarsByColorId(Guid.Parse("05b47ccb-d908-4437-bd46-072717897295")).Data;
        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}