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

    public DataResult<Color> GetById(Guid id)
    {
        return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id));
    }

    public Result RemoveById(Guid id)
    {
        var color = _colorDal.Get(c => c.ColorId == id);
        if (color == null)
        {
            return new ErrorResult("Color not found");
        }
        _colorDal.Delete(color);
        return new SuccessResult();
    }
}
