using Core.Utilities.Results.Abstract;
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
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int p);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int p);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult Add(Car car);
    }
}
