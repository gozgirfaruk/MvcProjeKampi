﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("e-Mail adresi boş geçilemez.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("En az 5 karakter gir.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("En az 3 karakter gir");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En fazla 50 karakter gir.");

        }
    }
}
