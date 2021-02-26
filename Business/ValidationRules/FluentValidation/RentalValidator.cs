using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.Validation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.RentDate).GreaterThanOrEqualTo(DateTime.Today);
            RuleFor(r => r.ReturnDate).Empty();

        }
    }
}
