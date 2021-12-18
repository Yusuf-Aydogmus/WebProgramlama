using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator :AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Ad boş geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail boş geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Sifre boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("İsim 3 karakterden az olmalıdır  ");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("İsim 20 karakterden çok olamaz");


        }
    }
}
