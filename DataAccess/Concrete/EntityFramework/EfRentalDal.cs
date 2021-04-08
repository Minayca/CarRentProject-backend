using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(int carId)
        {
            using (CarRentContext context = new CarRentContext())
            {
                var result = from r in context.Rentals
                             where r.CarId == carId

                             join c in context.Cars
                             on r.CarId equals c.Id

                             join b in context.Brands
                             on c.BrandId equals b.BrandId

                             join co in context.Colors
                             on c.ColorId equals co.ColorId

                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId

                             join u in context.Users
                             on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = c.Id,
                                 CustomerId = cu.CustomerId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 CustomerFirstName = u.FirstName,
                                 CustomerLastName = u.LastName,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();


            }
        }

    }
}
