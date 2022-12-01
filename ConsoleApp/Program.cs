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
            Car car1 = new Car {ColorId=1,BrandId=1,DailyPrice=-200,Description="denemearacı3",ModelYear="2200"};

            //Normal ekleme çalışıyor
            var result = carManager.Add(car1);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            Listele();
            //UcreteGoreListele(5200,6100);
            //ArabaListeleGetAll();





            void UcreteGoreListele(decimal min, decimal max)
            {
                var result = carManager.GetByDailyPrice(min, max);
                if (result.Success==true)
                {
                    foreach (var c in carManager.GetByDailyPrice(min, max).Data)
                    {
                        Console.WriteLine("Araç Açıklaması: " + c.Description + "\n" + "Araç Model Yılı: " + c.ModelYear +
                             "\n" + "Araç Günlük Fiyatı: " + c.DailyPrice + "\n" + "******************");
                    }
                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            }


            void Listele()
            {
                var result = carManager.GetAll();
                if (result.Success==true)
                {
                    foreach (var c in carManager.GetAll().Data)
                    {
                        Console.WriteLine("Araç Açıklaması: " + c.Description + "\n" + "Araç Model Yılı: " + c.ModelYear +
                        "\n" + "Araç Günlük Fiyatı: " + c.DailyPrice + "\n" + "******************");
                    }
                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            }
 
            
            
            void ArabaListeleGetAll()
            {
                var result = carManager.GetCarDetailDtos();
                if (result.Success==true)
                {
                    foreach (var c in carManager.GetCarDetailDtos().Data)
                    {
                        Console.WriteLine("Renk: " + c.ColorName + "\n" + "Renk Id: " + c.ColorId +
                        "\n" + "Açıklamaı: " + c.Description + "\n" + "******************");    //Sadece DTO ya eklediklerimizi yazabildik
                                                                                                //yani colortıd-colorname-desciription yazabiliriz.
                                                                                                //çünkü .GetProductDetailDtos çağırdık
                    }
                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            };
        
        
        
        }
    }
}
