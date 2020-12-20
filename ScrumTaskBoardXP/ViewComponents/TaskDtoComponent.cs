using Microsoft.AspNetCore.Mvc;
using ScrumTaskBoardXP.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Web.ViewComponents
{
    public class TaskDtoComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(TaskDto taskDto)
        {
            return View(taskDto);
        }
    }
}
