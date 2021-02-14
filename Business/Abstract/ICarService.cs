using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> Get(int Id);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult update(Car car);
        IDataResult<List<CarDetailDto>> GetDetailsAll();



    }
}
