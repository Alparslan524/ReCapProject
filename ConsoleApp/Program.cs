using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car {ColorId=2,BrandId=2,DailyPrice=5200,Description="Pahalı bir araba",ModelYear="2022"};
            
            
            Listele();
            Console.WriteLine("****************\n\n");


            //carManager.Add(car1); 1 kere ekledik 

            foreach (var c in carManager.GetByDailyPrice(5200, 10000))
            {
                Console.WriteLine("Araç Açıklaması: " + c.Description + "\n" + "Araç Model Yılı: " + c.ModelYear +
                     "\n" + "Araç Günlük Fiyatı: " + c.DailyPrice + "\n" + "******************");
            }








            void Listele()
            {
                foreach (var c in carManager.GetAll())
                {
                    Console.WriteLine("Araç Açıklaması: " + c.Description + "\n" + "Araç Model Yılı: " + c.ModelYear +
                    "\n" + "Araç Günlük Fiyatı: " + c.DailyPrice + "\n" + "******************");
                }
            }
        }
    }
}
