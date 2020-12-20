using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Enums;
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
