using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarServices
    {
        ICarDal _carDal;//Constructor injection
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            //işlemler
            return _carDal.GetAll();
        }

        public List<Car> GetbyId(int id)
        {
            //işlemler
            return _carDal.GetbyId(id);
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }
        
        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    
    }
}
