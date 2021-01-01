using FluentValidation;
using ScrumTaskBoardXP.Data.Dtos;

namespace ScrumTaskBoardXP.Business.Validations
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("İsim kısmı boş geçilemez").MaximumLength(100);
            RuleFor(I => I.Email).NotEmpty().WithMessage("E Posta adresi boş geçilemez").MaximumLength(100).EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz.");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Şifre kısmı boş geçilemez.").MaximumLength(32);
        }
    }
}
