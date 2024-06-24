using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IColorService
{
    public Result Add(Color brand);
    public Result Remove(Color brand);
    public Result Update(Color brand);

    public DataResult<List<Color>> GetAll();
    
    public DataResult<Color> GetById(Guid id);
    
    public Result RemoveById(Guid id);
    public Result RemoveByName(string name);
}