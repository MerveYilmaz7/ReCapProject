using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length<2 && car.DailyPrice<0)
            {
                return new ErrorResult(Messages.AddedError);
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

        public IResult update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}
