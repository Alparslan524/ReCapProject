using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemory : ICarDal
    {
        List<Car> _car;
        public InMemory()
        {
            _car = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=700, ModelYear="2020", Description="BWM,kırmızı,2020 Model"},
                new Car{Id=2, BrandId=1, ColorId=2, DailyPrice=900, ModelYear="2022", Description="BWM,mavi,2022 Model"},
                new Car{Id=3, BrandId=2, ColorId=1, DailyPrice=500, ModelYear="2019", Description="Mercedes,kırmızı,2019 Model"},
                new Car{Id=4, BrandId=3, ColorId=3, DailyPrice=5000, ModelYear="1952", Description="Ford,siyah,1952 Model"},
            };
        }
        
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car tempCar = _car.SingleOrDefault(c=>c.Id==car.Id);
            _car.Remove(tempCar);
        }

        public void Update(Car car)
        {
            Car tempCar = _car.SingleOrDefault(c=>c.Id==car.Id);
            tempCar.BrandId = car.BrandId;
            tempCar.ColorId = car.ColorId;
            tempCar.DailyPrice = car.DailyPrice;
            tempCar.ModelYear = car.ModelYear;
            tempCar.Description = car.Description;
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetbyId(int id)
        {
            //List<Car> tempCar = _car.Where(c => c.Id==id).ToList();
            //return tempCar;
            return _car.Where(c => c.Id==id).ToList(); //diyerek tek satırda da yazabilirdik
        }
    }
}
