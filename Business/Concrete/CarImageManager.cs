using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CarImageCount(carImage.Id));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> GetById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == Id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CarImageCount(int Id)
        {
            var result = _carImageDal.GetAll(i=>i.Id==Id).Count;
            if (result<5)
            {
                return new ErrorResult(Messages.CarImageCountError);
            }
            return new SuccessResult();
        }
    }
}
