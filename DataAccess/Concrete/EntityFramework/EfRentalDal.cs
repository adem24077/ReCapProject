using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, NorthwindContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {

            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from re in filter is null ? context.Rentals : context.Rentals.Where(filter)
                    join ca in context.Cars
                        on re.CarId equals ca.CarId
                    join cus in context.Customers
                        on re.CustomerId equals cus.CustomerId
                    join us in context.Users
                        on cus.UserId equals us.UserId
                    select new RentalDetailDto
                    {
                        RentalId = re.RentalId,
                        CarName = ca.CarName,
                        CustomerName = cus.CompanyName,
                        CarId = ca.CarId,
                        RentDate = re.RentDate,
                        ReturnDate = re.ReturnTime,
                        UserName = us.FirstName + " " + us.LastName
                    };

                return result.ToList();

            }
        }
    }
}
