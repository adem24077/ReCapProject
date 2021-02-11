using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car,bool>> filter=null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = 
                    from ca in filter is null ? 
                        context.Cars : context.Cars.Where(filter)
                    join co in context.Colors
                        on ca.ColorId equals co.ColorId
                    join b in context.Brands
                        on ca.BrandId equals b.BrandId
                    select new CarDetailDto
                    {
                        CarId = ca.CarId, 
                        BrandId = b.BrandId, 
                        BrandName = b.BrandName,
                        CarName = ca.CarName, 
                        ColorName = co.ColorName,
                        ColorId = ca.ColorId, 
                        DailyPrice = ca.DailyPrice,
                        Description = ca.Description, 
                        ModelYear = ca.ModelYear
                    };
                return result.ToList();
            }
        }
    }
}
