using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess.EntityFramework;

public class EfEntityRepositoryBase<T> : IEntityRepository<T> where T : class, IEntity, new()
{
    public void Add(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public T Get(Expression<Func<T, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public List<T> GetAll(Expression<Func<T, bool>> filter = null)
    {
        throw new NotImplementedException();
    }
}