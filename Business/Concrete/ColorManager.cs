using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ColorManager: IColorService
{
    private readonly IColorDal _colorDal;

    public ColorManager(IColorDal colorDal)
    {
        _colorDal = colorDal;
    }
    
    public Result Add(Color brand)
    {
        _colorDal.Add(brand);
        return new SuccessResult();
    }

    public Result Remove(Color brand)
    {
        _colorDal.Delete(brand);
        return new SuccessResult();
    }

    public Result Update(Color brand)
    {
        _colorDal.Update(brand);
        return new SuccessResult();
    }

    public DataResult<List<Color>> GetAll()
    {
        return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
    }
}
