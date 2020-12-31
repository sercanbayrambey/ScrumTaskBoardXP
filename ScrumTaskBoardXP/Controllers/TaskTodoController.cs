using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using ScrumTaskBoardXP.Entites.Enums;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Web.Controllers
{
    [Authorize]
    public class TaskTodoController : BaseController
    {
        private readonly ITaskTodosService _taskTodosService;
        private readonly IMapper _mapper;

        public TaskTodoController(ITaskTodosService taskTodosService, IMapper mapper)
        {
            _taskTodosService = taskTodosService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add(TaskTodosDto dto)
        {

            if (dto == null)
                return BadRequest();

            if (ModelState.IsValid)
                _taskTodosService.Add(_mapper.Map<TaskTodosEntity>(dto));
            else
                return BadRequest();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get(int taskId)
        {

            return Ok(await _taskTodosService.GetAllByTaskId(taskId));
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var todoToDelete = _taskTodosService.GetById(id);
            if (todoToDelete == null)
                return BadRequest();

            _taskTodosService.Delete(todoToDelete);
            return Ok();
        }

        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var todoToDelete = _taskTodosService.GetById(taskId);
            if (todoToDelete == null)
                return BadRequest();

            _taskTodosService.Delete(todoToDelete);
            SuccessAlert("Silme işlemi başarılı.");
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> ChangeTaskState(int id, string newState)
        {
            if (id < 0)
                return BadRequest();
            TaskTodoStatus taskState = new TaskTodoStatus();
            switch (newState)
            {
                case "todo":
                    taskState = TaskTodoStatus.Todo;
                    break;
                case "inProgress":
                    taskState = TaskTodoStatus.InProgress;
                    break;
                case "review":
                    taskState = TaskTodoStatus.InReview;
                    break;
                case "done":
                    taskState = TaskTodoStatus.Done;
                    break;
                default:
                    return BadRequest();

            }

            var stateResult = await _taskTodosService.ChangeTaskState(id, taskState);
            if (stateResult.Success)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Update(TaskTodosDto dto)
        {
            if (ModelState.IsValid)
            {
                var todoToUpdate = _taskTodosService.GetById(dto.Id);
                if (todoToUpdate == null)
                    return BadRequest();

                dto.TaskId = todoToUpdate.TaskId;
                _taskTodosService.Update(_mapper.Map(dto, todoToUpdate));
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }

}
