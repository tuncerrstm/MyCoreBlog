using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(W => W.WriterName).NotEmpty().WithMessage("Ad Soyad Boş Geçilemez!");
            RuleFor(W => W.WriterMail).NotEmpty().WithMessage("E-mail Boş Geçilemez!");
            RuleFor(W => W.WriterPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez!");
            //RuleFor(W => W.WriterPasswordRepeat).NotEmpty().WithMessage("Şifre Tekrarı Boş Geçilemez!");
            RuleFor(W => W.WriterName).MinimumLength(2).WithMessage("Minimum 2 karekter girişi yapınız!");
            RuleFor(W => W.WriterName).MaximumLength(50).WithMessage("Maximum 50 karekter girişi yapınız!");
            RuleFor(W => W.WriterImage).NotEmpty().WithMessage("Lütfen bir fotoğraf seçiniz!");
            //RuleFor(w => w.WriterPassword).Must(IsPasswordValid).WithMessage("Parolanızda en az bir küçük harf bir büyük harf ve rakam olmalıdır!");
            RuleFor(x => x.WriterPassword).MinimumLength(6).WithMessage("Parolanız en az 6 karakter içermelidir.");
            RuleFor(x => x.WriterPassword).Must(IsPasswordValid).WithMessage("Parolanızda en az bir küçük harf bir büyük harf ve rakam içermelidir.");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Lütfen geçerli bir e-mail giriniz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkınızda kısmı boş Bırakılamaz.");
        }

        private bool IsPasswordValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");
                return regex.IsMatch(arg);
            }
            catch
            {
                return false;
            }
        }
    }
}
