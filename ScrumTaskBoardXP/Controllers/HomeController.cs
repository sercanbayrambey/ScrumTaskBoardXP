using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Enums;
using ScrumTaskBoardXP.Models;
using ScrumTaskBoardXP.Web.Controllers;
using ScrumTaskBoardXP.Web.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ITaskService _taskService;
        private readonly ITaskTodosService _taskTodosService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public HomeController(ITaskService taskService, ITaskTodosService taskTodosService, IMapper mapper, IUserService userService)
        {
            _taskService = taskService;
            _taskTodosService = taskTodosService;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var dto = await _taskService.GetAllWithUser();
            TasksViewModel tasksViewModel = new TasksViewModel
            {
                DoneTasks = dto.Where(I => I.Status == EntityTaskStatus.Done).ToList(),
                InProgressTasks = dto.Where(I => I.Status == EntityTaskStatus.InProgress).ToList(),
                InReviewTasks = dto.Where(I => I.Status == EntityTaskStatus.InReview).ToList(),
                TodoTasks = dto.Where(I => I.Status == EntityTaskStatus.Todo).ToList(),
                TaskDto = new TaskDto()
            };
            ViewBag.Users = _mapper.Map<List<UserDto>>(_userService.GetAll());
            return View(tasksViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
