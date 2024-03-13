using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Mail kutusu boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu başlığı boş geçilemez");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj kutusu boş geçilemez");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter giriniz.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("En fazla 20 karakter giriniz.");
            RuleFor(x => x.MessageContent).MinimumLength(10).WithMessage("En az 10 karakter giriniz.");


        }
    }
}
