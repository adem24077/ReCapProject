using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarsByBrandId(int p);
        List<CarDetailDto> GetCarsByColorId(int p);
        void Update(Car car);
        void Delete(Car car);
        void Add(Car car);
    }
}
