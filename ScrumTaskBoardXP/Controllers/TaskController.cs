using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using ScrumTaskBoardXP.Entites.Enums;
using System;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Web.Controllers
{
    [Authorize]
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
            taskEntity.DateAdded = DateTime.Now;
            _taskService.Add(taskEntity);
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Update(int id)
        {
            var task = _taskService.GetById(id);
            if (task == null)
                return NotFound();
            var taskDto = _mapper.Map<TaskDto>(task);
            return View(taskDto);
        }


        [HttpPost]
        public IActionResult Update(TaskDto taskDto)
        {
            if (taskDto == null)
                return NotFound();
            if (ModelState.IsValid)
            {
                _taskService.Update(_mapper.Map<TaskEntity>(taskDto));
                return RedirectToAction("Update", new { id = taskDto.Id });
            }
            else
                return View(taskDto);
        }


        [HttpPost]
        public async Task<IActionResult> ChangeTaskState(int id, string newState)
        {
            if (id < 0)
                return BadRequest();
            EntityTaskStatus taskState = new EntityTaskStatus();
            switch (newState)
            {
                case "todo":
                    taskState = EntityTaskStatus.Todo;
                    break;
                case "inProgress":
                    taskState = EntityTaskStatus.InProgress;
                    break;
                case "review":
                    taskState = EntityTaskStatus.InReview;
                    break;
                case "done":
                    taskState = EntityTaskStatus.Done;
                    break;
                default:
                    return BadRequest();

            }

            await _taskService.ChangeTaskState(id, taskState);

            return Ok();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var taskToDelete = _taskService.GetById(id);
            if (taskToDelete == null)
                return BadRequest();
            _taskService.Delete(taskToDelete);
            return RedirectToAction("Index","Home");
        }
    }
}
