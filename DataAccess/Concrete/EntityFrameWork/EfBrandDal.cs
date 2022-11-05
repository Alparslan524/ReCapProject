using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand brand)
        {
            using (ReCapProjectsContext northWindContext = new ReCapProjectsContext())
            {
                var addedBrand = northWindContext.Entry(brand);
                addedBrand.State = EntityState.Added;
                northWindContext.SaveChanges();
            }
        }

        public void Delete(Brand brand)
        {
            using (ReCapProjectsContext northWindContext = new ReCapProjectsContext())
            {
                var deletedBrand = northWindContext.Entry(brand);
                deletedBrand.State = EntityState.Deleted;
                northWindContext.SaveChanges();
            }
        }
        public void Update(Brand brand)
        {
            using (ReCapProjectsContext northWindContext = new ReCapProjectsContext())
            {
                var updatedBrand = northWindContext.Entry(brand);
                updatedBrand.State = EntityState.Modified;
                northWindContext.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
