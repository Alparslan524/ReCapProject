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
            Car car1 = new Car {ColorId=1,BrandId=1,DailyPrice=4200,Description="denemearacı",ModelYear="2000"};
            
            //Normal ekleme çalışıyor
            carManager.Add(car1);

            Listele();
            //UcreteGoreListele(5200,6100);







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
