using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CarManager carManager = new CarManager(new EfCarDal());

            brandManager.Add(new Brand { BrandId = 3, BrandName = "BMW" });
            brandManager.Add(new Brand { BrandId = 4, BrandName = "BM" });
            colorManager.Add(new Color { ColorId = 1, ColorName = "Siyah" });

            //colorManager.Delete(colorManager.GetById(3));
        }
    }
}
