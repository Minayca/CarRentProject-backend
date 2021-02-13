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
            //CarManager carManager = new CarManager(new EfCarDal());

            //var result = carManager.GetCarDetails();
            //if (result.Success == true)
            //{
            //    foreach (var car in result.Data)
            //    {
            //        Console.WriteLine("{0} / {1} / {2} / {3}", car.Id, car.BrandName, car.ColorName, car.DailyPrice);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}

            //ColorManager colorManager = new ColorManager(new EfColorDal());

            //var a = colorManager.Add(new Color { ColorId = 3, ColorName = "Siyah" });
            //Console.WriteLine(a.Message);

            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            userManager.Add(new User 
            { Id=1, FirstName="Mina", LastName="KANBERK", Email="m.aycaknbrk@gmail.com", Password="123456789a"});
            
            customerManager.Add(new Customer { CustomerId = 1, UserId = 1, CompanyName = "AFK" });

        }
    }
}
