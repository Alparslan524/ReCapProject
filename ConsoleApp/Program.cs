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
            Car car1 = new Car {ColorId=2,BrandId=2,DailyPrice=-50,Description="Günlük ücreti 0dan büyük olmalıdır. Bunu test ediyorum",ModelYear="2022"};
            
            //Normal ekleme çalışıyor
            carManager.Add(car1);
            //Listele();
            UcreteGoreListele(5200,6100);







            void UcreteGoreListele(decimal min, decimal max)
            {
                foreach (var c in carManager.GetByDailyPrice(min, max))
                {
                    Console.WriteLine("Araç Açıklaması: " + c.Description + "\n" + "Araç Model Yılı: " + c.ModelYear +
                         "\n" + "Araç Günlük Fiyatı: " + c.DailyPrice + "\n" + "******************");
                }
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
