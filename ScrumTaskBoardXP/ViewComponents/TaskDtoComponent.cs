using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScrumTaskBoardXP.Business.Abstract;
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
        private readonly IUserService _userService;
        public TaskDtoComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync(TaskDto taskDto)
        {
            ViewBag.UsersList = new SelectList(_userService.GetAll(), "Id", "Name");
            return View(taskDto);
        }

    
    }
}
