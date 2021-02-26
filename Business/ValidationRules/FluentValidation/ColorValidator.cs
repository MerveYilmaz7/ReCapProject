﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.Validation
{
    public class ColorValidator:AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ColorName).NotEmpty();
            RuleFor(c => c.ColorName).MinimumLength(2);
        }
    }
}