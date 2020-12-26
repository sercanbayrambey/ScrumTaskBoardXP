using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class TaskTodoController : Controller
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
