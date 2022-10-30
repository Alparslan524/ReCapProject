using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemory());

            Listele();
            Console.WriteLine("\n\n\n");


            Car car1 = new Car
            {
                Id = 5, BrandId = 3, ColorId = 1, DailyPrice=6000, ModelYear="1970", Description="Ford,kırmızı, 1970 model"
            };
            carManager.Add(car1);
            Console.WriteLine("Araç Eklenecek\n");
            Listele();

            carManager.Delete(car1);
            Console.WriteLine("Car1 Silindi\n");
            Listele();

            void Listele()
            {
                foreach (var c in carManager.GetAll())
                {
                    Console.WriteLine("Araç Açıklaması: " + c.Description + "\n" + "Araç Model Yılı: " + c.ModelYear +
                    "\n" + "Araç Günlük Fiyatı: " + c.DailyPrice + "\n" + "******************");
                }
            };
        }
    }
}
