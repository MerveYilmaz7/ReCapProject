using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepository<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetDetailsAll()
        {
            using (ReCapProjectContext context =new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join cr in context.Colors
                             on c.ColorId equals cr.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             orderby c.CarName ascending
                             select new  CarDetailDto {CarName=c.CarName,BrandName=b.BrandName,ColorName=cr.ColorName,DailyPrice=c.DailyPrice };
                return result.ToList();
            }
        }
    }
}
