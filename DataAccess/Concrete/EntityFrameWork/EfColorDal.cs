using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfColorDal : IColorDal
    {
        public void Add(Colors colors)
        {
            using (ReCapProjectsContext northWindContext = new ReCapProjectsContext())
            {
                var addedColors = northWindContext.Entry(colors);
                addedColors.State = EntityState.Added;
                northWindContext.SaveChanges();
            }
        }

        public void Delete(Colors colors)
        {
            using (ReCapProjectsContext northWindContext = new ReCapProjectsContext())
            {
                var deletedColors = northWindContext.Entry(colors);
                deletedColors.State = EntityState.Deleted;
                northWindContext.SaveChanges();
            }
        }

        public Colors Get(Expression<Func<Colors, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Colors> GetAll(Expression<Func<Colors, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Colors colors)
        {
            using (ReCapProjectsContext northWindContext = new ReCapProjectsContext())
            {
                var updatedColors = northWindContext.Entry(colors);
                updatedColors.State = EntityState.Modified;
                northWindContext.SaveChanges();
            }
        }
    }
}
