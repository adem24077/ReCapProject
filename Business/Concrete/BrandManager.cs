using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("{0} succesfully added\n", brand.BrandName);
            }
            else
            {
                Console.WriteLine("Brand name must be at least 2 characters\n", brand.BrandName);
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("brand succesfully deleted\n");
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
            Console.WriteLine("brand succesfully updated\n");
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(p => p.BrandId == id);
        }

        public List<Brand> GetAll()
        {
            Console.WriteLine("ALL BRANDS\n");
            return _brandDal.GetAll();

        }

    }
}
