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
        return new SuccessResult();
    }

    public Result Remove(Brand brand)
    {
        _brandDal.Delete(brand);
        return new SuccessResult();
    }

    public Result Update(Brand brand)
    {
        _brandDal.Update(brand);
        return new SuccessResult();
    }

    public DataResult<List<Brand>> GetAll()
    {
        return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
    }
}