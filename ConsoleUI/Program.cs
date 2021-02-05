using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Console.WriteLine(carManager.GetById(3).Description); 

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            
        }
    }
}
