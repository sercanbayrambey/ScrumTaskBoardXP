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
        private readonly IProjectService _projectService;
        private readonly ITaskTodosService _taskTodosService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public HomeController(IProjectService projectService, ITaskTodosService taskTodosService, IMapper mapper, IUserService userService)
        {
            _projectService = projectService;
            _taskTodosService = taskTodosService;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var taskTodoList = await _taskTodosService.GetAllEagerAsync();
            HomeViewModel tasksViewModel = new HomeViewModel
            {
                DoneTasks = taskTodoList.Where(I => I.Status == TaskTodoStatus.Done).ToList(),
                InProgressTasks = taskTodoList.Where(I => I.Status == TaskTodoStatus.InProgress).ToList(),
                InReviewTasks = taskTodoList.Where(I => I.Status == TaskTodoStatus.InReview).ToList(),
                TodoTasks = taskTodoList.Where(I => I.Status == TaskTodoStatus.Todo).ToList(),
                TaskDto = new ProjectDto(),
                Projects = _mapper.Map<List<ProjectDto>>(await _projectService.GetAllEagerAsync())
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
