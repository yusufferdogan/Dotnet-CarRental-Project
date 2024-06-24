using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class BrandManager:IBrandService
{
    private readonly IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }

    public Result Add(Brand brand)
    {
        _brandDal.Add(brand);
        return new SuccessResult("Brand added successfully.");
    }

    public Result Remove(Brand brand)
    {
        _brandDal.Delete(brand);
        return new SuccessResult("Brand removed successfully.");
    }

    public Result Update(Brand brand)
    {
        _brandDal.Update(brand);
        return new SuccessResult("Brand updated successfully.");
    }

    public DataResult<List<Brand>> GetAll()
    {
        return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
    }

    public DataResult<Brand> GetById(Guid id)
    {
        return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
    }

    public Result RemoveById(Guid id)
    {
        var brand = _brandDal.Get(b => b.BrandId == id);
        if (brand == null)
        {
            return new ErrorResult();
        }
        _brandDal.Delete(brand);
        return new SuccessResult("Brand removed successfully.");
    }
}