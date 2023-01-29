using Business.Abstract;
using Business.Constants;
using Business.DependencyResolvers.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarServices
    {
        ICarDal _carDal;//Constructor injection
        IBrandServices _brandServices;
        //IBrandDal _brandDal; Bir manager sadece kendi DALını Constructor injection yapabilir. Bu yüzden serviceyi injection yaptık
        public CarManager(ICarDal carDal, IBrandServices brandServices)
        {
            _carDal = carDal;
            _brandServices = brandServices;
            //_brandDal = brandDal;
        }
        
        [CacheAspect]//Eğer cachede data yoksa Datayı cacheye ekledi. Daha sonraki isteklerde de cachedeki hazır datayı gönderdi.
                     //Her seferinde veritabanına istek göndermedi
        public IDataResult<List<Car>> GetAll()
        {
            //işlemler  
            return new SuccessDataResult<List<Car>>(_carDal.GetAll().ToList(), Messages.CarListed);
        }
        
        
        [CacheRemoveAspect("ICarServices.Get")]//Başarılı bir add işleminden sonra keyi ICarService.Get olan dataları siler.
                            //Datayı manipüle eden methodlarda kullanırız. Data eklendiğinde değişeceğinde güncellendiğinde vs
                            //veri cacheden alınır. Çünkü veri değiştikten sonra get işlemlerinde cachedeki eski veriyi gösterir
        [ValidationAspect(typeof(CarValidator))]
        [TransactionScopeAspect]
        public IResult Add(Car car)
        {
            //if (car.DailyPrice>=0)
            //{
            //    _carDal.Add(car);
            //    return new SuccessResult(Messages.CarAdded);
            //}
            //else
            //{
            //    return new ErrorResult(Messages.FalseDailyPrice);
            //} Fluent Validation Öncesi kodu

            IResult result = BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId), CheckSameDescription(car.Description),
                MaxQuantityOfBrands());

            if (result!=null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max).ToList(), Messages.ListedByPrice);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos(), Messages.CarDetailListed);
        }
        
        private IResult CheckIfCarCountOfBrandCorrect(int brandId)// Product product da diyebilirdik.
                                                                  // Ama solidin S si olduğu için bu method sadece 1 özelliği kontrol ediyor
                                                                  //başka özellikler başka methodda
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.BrandQuantityError);
            }//Bir markanın max 10 arabası olabilir
            return new SuccessResult();
        }

        private IResult CheckSameDescription(string desciription)
        {
            var result = _carDal.GetAll(c => c.Description == desciription).Count;
            if (result!=0)
            {
                return new ErrorResult(Messages.SameDescription);
            }//Aynı açıklamaya sahip başka bir araç olamaz
            return new SuccessResult();
        }

        private IResult MaxQuantityOfBrands()
        {
            var quantityBrand = _brandServices.GetAll().Data.Count;
            if (quantityBrand>15)
            {
                return new ErrorResult(Messages.MaxBrandQuantity);
            }//Marka Sayısı 15i geçtiyse ürün eklenemez
            return new SuccessResult();
        }
    }
}
