using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidaitonRules.FluentValidation
{
    class RentalValidator : AbstractValidator<Rental>
    {

        public RentalValidator()
        {
            RuleFor(x => x.CarId).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.RentDate).NotEmpty();
        }

    }
}
