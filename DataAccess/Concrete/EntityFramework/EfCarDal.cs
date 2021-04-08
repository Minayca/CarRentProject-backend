using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentContext>, ICarDal
    {
        public List<CarDetailDto> GetCarFilterBrandIdColorId(int brandId, int colorId)
        {
            using (CarRentContext context = new CarRentContext())
            {
                var result = (from c in context.Cars
                              join co in context.Colors on c.ColorId equals co.ColorId
                              join b in context.Brands on c.BrandId equals b.BrandId
                              where c.ColorId == colorId && b.BrandId == brandId
                              select new CarDetailDto
                              {
                                  Id = c.Id,
                                  Description = c.Description,
                                  BrandId = b.BrandId,
                                  DailyPrice = c.DailyPrice,
                                  BrandName = b.BrandName,
                                  ColorId = co.ColorId,
                                  ColorName = co.ColorName,
                                  ModelYear = c.ModelYear
                              }).ToList();
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentContext context = new CarRentContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            using (CarRentContext context = new CarRentContext())
            {
                var result = from c in context.Cars
                             where c.Id == carId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            using (CarRentContext context = new CarRentContext())
            {
                var result = from c in context.Cars
                             where c.BrandId == brandId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            using (CarRentContext context = new CarRentContext())
            {
                var result = from c in context.Cars
                             where c.ColorId == colorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
