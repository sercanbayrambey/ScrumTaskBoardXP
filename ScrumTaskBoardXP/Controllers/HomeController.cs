using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Logging;
using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Enums;
using ScrumTaskBoardXP.Models;
using ScrumTaskBoardXP.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly ITaskTodosService _taskTodosService;
        private readonly IMapper _mapper;
        public HomeController(ITaskService taskService, ITaskTodosService taskTodosService, IMapper mapper)
        {
            _taskService = taskService;
            _taskTodosService = taskTodosService;
            _mapper = mapper;
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
