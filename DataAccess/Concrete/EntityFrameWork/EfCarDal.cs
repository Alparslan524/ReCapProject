using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarDal : ICarDal
    {

        public void Add(Car car)
        {
            using (ReCapProjectsContext northWindContext=new ReCapProjectsContext())
            {
                var addedCar = northWindContext.Entry(car);
                addedCar.State = EntityState.Added;
                northWindContext.SaveChanges();
            }
        }

        public void Delete(Car car)
        {
            using (ReCapProjectsContext northWindContext = new ReCapProjectsContext())
            {
                var deletedCar = northWindContext.Entry(car);
                deletedCar.State = EntityState.Deleted;
                northWindContext.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapProjectsContext context = new ReCapProjectsContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectsContext context = new ReCapProjectsContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }                         //select * from products döndürür : //filtreli halini döndürür
        }

        public void Update(Car car)
        {
            using (ReCapProjectsContext northWindContext = new ReCapProjectsContext())
            {
                var updatedCar = northWindContext.Entry(car);
                updatedCar.State = EntityState.Modified;
                northWindContext.SaveChanges();
            }
        }
    }
}
