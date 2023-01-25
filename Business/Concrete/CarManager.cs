using Business.Abstract;
using Business.Constants;
using Business.DependencyResolvers.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            //işlemler  
            return new SuccessDataResult<List<Car>>(_carDal.GetAll().ToList(), Messages.CarListed);
        }
        
        [ValidationAspect(typeof(CarValidator))]
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

            if (CheckIfCarCountOfBrandCorrect(car.BrandId).Success)
            {
                if (CheckSameDescription(car.Description).Success)
                {
                    _carDal.Add(car);
                    return new SuccessResult(Messages.CarAdded);
                }
                return new ErrorResult(Messages.SameDescription);
            }
            return new ErrorResult(Messages.BrandQuantityError);
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }


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
            }
            return new SuccessResult();
        }
    }
}
