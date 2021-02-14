using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Car();
            UserTest();
            CustomerTest();
            RentCarTest();

        }

        private static void RentCarTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { Id = 6, CarId = 3, CustomerId = 4, RentDate = new DateTime(2021, 2, 14) });
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Get(1);
            Console.WriteLine(result.Data.CompanyName);

            foreach (var custom in customerManager.GetAll().Data)
            {
                Console.WriteLine(custom.CustomerId + " " + custom.CompanyName);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { UserId = 5, FirstName = "Merve", LastName = "Yılmaz", Email = "merve@gmail.com", Passwrd = 32645 });
            foreach (var users in userManager.GetAll().Data)
            {
                Console.WriteLine(users.FirstName + " " + users.LastName);
            }
        }

        private static void Car()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car {Id=7,CarName="i20",BrandId=1,ColorId=1,DailyPrice=0,Descriptions="Car7" });
            //foreach (var car in carManager.GetDetailsAll().Data)
            //{
            //    Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);

            //}
            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var car in carManager.GetAll().Data)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
