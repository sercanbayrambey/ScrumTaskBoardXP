using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Data.Dtos;
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

        public async Task<IViewComponentResult> InvokeAsync(ProjectDto taskDto)
        {
            ViewBag.UsersList = new SelectList(_userService.GetAll(), "Id", "Name");
            return View(taskDto);
        }


    }
}
