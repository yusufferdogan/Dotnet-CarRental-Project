using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IBrandService
{
    public Result Add(Brand brand);
    public Result Remove(Brand brand);
    public Result Update(Brand brand);

    public DataResult<List<Brand>> GetAll();
}