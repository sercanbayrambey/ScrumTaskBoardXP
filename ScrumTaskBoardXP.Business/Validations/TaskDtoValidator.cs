using FluentValidation;
using ScrumTaskBoardXP.Data.Dtos;

namespace ScrumTaskBoardXP.Business.Validations
{
    public class TaskDtoValidator : AbstractValidator<TaskDto>
    {
        public TaskDtoValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Isim kısmı zorunludur.").MaximumLength(200);
            RuleFor(I => I.Status).NotNull().WithMessage("Görev durumu boş geçilemez.");
        }
    }
}
