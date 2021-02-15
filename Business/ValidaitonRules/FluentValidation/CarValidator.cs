﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ValidaitonRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.CarName).MinimumLength(2).WithMessage("Araç adı en az 2 karakter uzunluğunda olmalıdır.");
            RuleFor(x => x.DailyPrice).GreaterThan(0).WithMessage("Aracın günlük fiyatı 0'dan büyük olmalıdır.");
            RuleFor(x => x.ModelYear).GreaterThan(0).WithMessage("Aracın model yılı 0'dan büyük olmalıdır.");
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("Araç açıklaması en az 5 karakter uzunluğunda olmalıdır.");
        }
    }
}