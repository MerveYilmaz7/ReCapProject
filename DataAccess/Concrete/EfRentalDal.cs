using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfRentalDal : EfEntityRepository<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             select new RentalDetailDto {Id=r.Id,CarName=c.CarName,RentDate=r.RentDate,ReturnDate=r.ReturnDate };
                return result.ToList();
            }
        }
    }
}
