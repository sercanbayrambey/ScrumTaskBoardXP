using FluentValidation;
using ScrumTaskBoardXP.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Business.Validations
{
    public class TaskTodoDtoValidator : AbstractValidator<TaskTodosDto>
    {
        public TaskTodoDtoValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Görev ismi boş geçilemez.").MaximumLength(64);
            RuleFor(I => I.Status).NotNull().WithMessage("Görev durumu boş geçilemez.");
        }
    }
}
