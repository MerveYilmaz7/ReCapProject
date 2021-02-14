﻿using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> Get(int ColorId);
        IResult Add(Color color);
        IResult Delete(Color color);
        IResult update(Color color);
    }
}
