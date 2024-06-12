// See https://aka.ms/new-console-template for more information

using DataAccess.Concrete.InMemory;

class Program
{
    static void Main(string[] args)
    {
        InMemoryCarDal carDal = new InMemoryCarDal();
        foreach (var car in carDal.GetAll())
        {
            Console.WriteLine(car);
        }
    }
}