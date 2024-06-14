// See https://aka.ms/new-console-template for more information

using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

class Program
{
    static void Main(string[] args)
    {
        EfCarDal carDal = new EfCarDal();
        foreach (var car in carDal.GetCarsDetails())
        {
            Console.WriteLine(car);
        }
    }
}