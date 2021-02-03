using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryProductDal()
        {
            _cars = new List<Car>
            {
                new Car{BrandId = 1, CarId = 1,ColorId = 125,DailyPrice =250, Description = "Sedan tip araç",ModelYear = 2016},
                new Car{BrandId = 2, CarId = 2,ColorId = 145,DailyPrice =150, Description = "Ticari araç",ModelYear = 2015},
                new Car{BrandId = 3, CarId = 3,ColorId = 175,DailyPrice =500, Description = "Lüks araç",ModelYear = 2014},
                new Car{BrandId = 4, CarId = 4,ColorId = 95,DailyPrice =5000, Description = "Limuzin",ModelYear = 2020},
                new Car{BrandId = 5, CarId = 5,ColorId = 65,DailyPrice =850, Description = "Jip",ModelYear = 2019}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete =_cars.SingleOrDefault(c=>c.BrandId==car.BrandId);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.BrandId == car.BrandId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.CarId = car.CarId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }

        public List<Car> GetAllById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }
    }
}
