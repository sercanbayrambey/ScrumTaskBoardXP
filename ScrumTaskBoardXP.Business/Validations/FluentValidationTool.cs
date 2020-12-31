using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Business.Validations
{
    public static class FluentValidationTool
    {
        public static bool Validate<T>(IValidator<T> validator, T entity)
        {
            var result = validator.Validate(entity);
            if (!result.IsValid)
            {
                return false;
            }
            return true;
        }
    }
}
