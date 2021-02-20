using Business.Abstract;
using Business.Constants;
using Business.Utilities;
using Business.ValidaitonRules.FluentValidation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IResult Add(Brand brand)
        {
            var validationResult = ValidationTool.Validate(new BrandValidator(), brand);
            if (validationResult.Errors.Count > 0)
            {
                return new ErrorResult(validationResult.Errors.Select(x => x.ErrorMessage).Aggregate((a, b) => $"--{a}\n--{b}"));
            }
            else if (_brandDal.Get(c => c.BrandName.ToLower() == brand.BrandName.ToLower()) != null)
            {
                return new ErrorResult(Messages.BrandAddError);
            }

            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
        }

        public IResult Update(Brand brand)
        {
            var validationResult = ValidationTool.Validate(new BrandValidator(), brand);
            if (validationResult.Errors.Count > 0)
            {
                return new ErrorResult(validationResult.Errors.Select(x => x.ErrorMessage).Aggregate((a, b) => $"--{a}\n--{b}"));
            }
            else if (_brandDal.Get(c => c.BrandName.ToLower() == brand.BrandName.ToLower()) != null)
            {
                return new ErrorResult(Messages.BrandAddError);
            }

            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

    }
}
