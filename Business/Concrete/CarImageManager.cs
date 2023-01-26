using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageServices
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal,ICarServices carServices)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(MaxImage(carImage.CarId));
            if (result!=null)
            {
                return result;
            }
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll().ToList(), Messages.CarImageListed);
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            IResult result = BusinessRules.Run(DefaultImage(carId));

            if (result != null)
            {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId).ToList(), Messages.GetImagesByCarIdListed);
            }
            
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId).ToList(), Messages.DefaultCarImageAdded);
            
        }


        private IResult MaxImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.MaxImageError);
            }//Bir aracın max 5 resmi olabilir
            return new SuccessResult();
        }

        private IResult DefaultImage(int carId)
        {
            var carImage = _carImageDal.GetAll(c => c.CarId == carId).ToList();
            if (carImage.Count != 0)
            {
                return new ErrorResult();
            }
            CarImage carImage1 = new CarImage();
            carImage1.CarId = carId;
            carImage1.Date = DateTime.Now;
            carImage1.ImagePath = "default ımage path";
            _carImageDal.Add(carImage1);
            return new SuccessResult();
        }
    }
}
