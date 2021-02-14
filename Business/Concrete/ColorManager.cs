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
   public class ColorManager:IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Color> Get(int ColorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c=>c.ColorId==ColorId));
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Day == 12)
            {
                return new ErrorDataResult<List<Color>>(Messages.Maintenance);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IResult update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.Updated);
        }
    }
}
