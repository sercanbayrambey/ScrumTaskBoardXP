using FluentValidation;
using ScrumTaskBoardXP.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Business.Validations
{
    public class TaskDtoValidator : AbstractValidator<TaskDto>
    {
        public TaskDtoValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Isim kısmı zorunludur.").MaximumLength(200);
            RuleFor(I => I.Status).NotEmpty().WithMessage("Görev durumu boş geçilemez.");
        }
    }
}
