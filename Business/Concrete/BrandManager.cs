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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Brand> Get(int BrandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(c=>c.BrandId==BrandId));
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Day == 12)
            {
                return new ErrorDataResult<List<Brand>>(Messages.Maintenance);
              }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.GetAll);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.Updated);
        }
    }
}
