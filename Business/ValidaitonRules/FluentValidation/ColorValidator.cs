using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidaitonRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(x => x.ColorName).MinimumLength(2).WithMessage("Renk adı en az 2 karakter uzunluğunda olmalıdır.");
        }
    }
}
