using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework;

public class EfEntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity> 
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
{
    public void Add(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            var addedEntity = context.Add(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Delete(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            var removedEntity = context.Remove(entity);
            removedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }

    public void Update(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            var updatedEntity = context.Update(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();   
        }
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        using (TContext context = new TContext())
        {
            return context.Set<TEntity>().SingleOrDefault(filter);
        }
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
    {
        using (TContext context = new TContext())
        {
            return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
        }
    }
}