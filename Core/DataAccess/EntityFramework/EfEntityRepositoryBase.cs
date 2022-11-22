using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity>
        where TEntity:class, IEntity, new()
        where TContext: DbContext, new()
    {
        public void Add(TEntity car)
        {
            using (TContext northWindContext = new TContext())
            {
                var addedCar = northWindContext.Entry(car);
                addedCar.State = EntityState.Added;
                northWindContext.SaveChanges();
            }
        }

        public void Delete(TEntity car)
        {
            using (TContext northWindContext = new TContext())
            {
                var deletedCar = northWindContext.Entry(car);
                deletedCar.State = EntityState.Deleted;
                northWindContext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }                         //select * from products döndürür : //filtreli halini döndürür
        }

        public void Update(TEntity car)
        {
            using (TContext northWindContext = new TContext())
            {
                var updatedCar = northWindContext.Entry(car);
                updatedCar.State = EntityState.Modified;
                northWindContext.SaveChanges();
            }
        }
    }
}
