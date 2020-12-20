using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _mapper = mapper;
            _taskService = taskService;
        }


        [HttpPost]
        public IActionResult Add(TaskDto taskDto)
        {
            var taskEntity = _mapper.Map<TaskEntity>(taskDto);
            _taskService.Add(taskEntity);
            return RedirectToAction("Index", "Home");

        }
    }
}
