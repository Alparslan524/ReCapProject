using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        
        public void Add(Car car)
        {
            if (car.DailyPrice>=0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araç eklendi!!!");
            }
            else
            {
                Console.WriteLine("Günlük Fiyat Sıfırdan Büyük Olmalıdır. Araç ekleme başarısız");
            }
            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }
        
        public void Update(Car car)
        {
            _carDal.Update(car);
        }
        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            return _carDal.GetCarDetailDtos();
        }
    }
}
