using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //Data Transformation OBject
            //CarTest();
            //IoC
            //BrandTest();
            ColorTest();
            GetAllUser();


        }
        private static void GetAllUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            Console.WriteLine("Kullanıcı Listesi: \nId\tFirst Name\tLast Name\tEmail\tPassword");
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine($"{user.Id}\t{user.FirstName}\t{user.LastName}\t{user.Password}");
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.BrandName);
            //}
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //foreach (var car in carManager.GetCarsByBrandId(1))
            //{

            //    Console.WriteLine(car);
            //}
        }
    }
}
