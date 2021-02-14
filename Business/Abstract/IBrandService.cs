using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> Get(int BrandId);
        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IResult update(Brand brand);
    }
}
