using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Yazar Adı Boş Geçilemez");
            RuleFor(x => x.FirstName).MinimumLength(3).WithMessage("En az 3 karakter girilmelidir");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Yazar Soyadı Boş Geçilemez");
            RuleFor(x => x.LastName).MaximumLength(20).WithMessage("En fazla 20 karakter olmalıdır.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda Boş Geçilemez");
        }
    }
}
