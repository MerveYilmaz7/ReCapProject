using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.Validation;
using Core.Aspects.Autofac.Cache;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;

        public CarManager(ICarDal carDal,IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfBrandCarCountOfBrandCorrect(car.BrandId), CheckIfCarNameExists(car.CarName), CheckIfBrandLimitExceded());
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Car> Get(int Id)
        {
           
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.Id==Id));
        }

        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Day==12)
            {
                return new ErrorDataResult<List<Car>>(Messages.Maintenance);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.GetAll);
        }

        public IDataResult<List<CarDetailDto>> GetDetailsAll()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetDetailsAll(),Messages.CarDetailDto);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfBrandCarCountOfBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result>=15)
            {
                return new ErrorResult(Messages.CheckIfBrandCarCountOfBrandCorrectError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarNameExists(string carName)
        {
            var result = _carDal.GetAll(c => c.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CheckIfCarNameExistsError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfBrandLimitExceded()
        {
            var result = _brandService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CheckIfBrandLimitExcededError);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
