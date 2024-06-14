using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICarService
{
    public List<Car> GetCarsByColorId(Guid colorId);

    public List<Car> GetCarsByBrandId(Guid brandId);

    public void Add(Car car);

    public void Remove(Car car);

    public void Update(Car car);
}