using AutoMapper;
using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Business.Results;
using ScrumTaskBoardXP.Data.Abstract;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using ScrumTaskBoardXP.Entites.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Business.Concrete
{
    public class TaskTodosManager : GenericManager<TaskTodosEntity>, ITaskTodosService
    {
        private readonly ITaskTodosDAL _taskTodosDAL;
        private readonly IMapper _mapper;

        public TaskTodosManager(ITaskTodosDAL taskTodosDAL, IMapper mapper) : base(taskTodosDAL)
        {
            _mapper = mapper;
            _taskTodosDAL = taskTodosDAL;
        }

        public async Task<IResult> ChangeTaskState(int taskId, TaskTodoStatus newStatus)
        {

            var taskToChange = GetById(taskId);

            if (taskToChange == null)
                return new ErrorResult();

            taskToChange.Status = newStatus;
            Update(taskToChange);

            return new Result();
        }

        public async Task<List<TaskTodosDto>> GetAllByTaskId(int taskId)
        {
            return _mapper.Map<List<TaskTodosDto>>(await _taskTodosDAL.GetAllByTaskId(taskId));
        }

        public async Task<List<TaskTodosDto>> GetAllEagerAsync()
        {
            return _mapper.Map<List<TaskTodosDto>>(await _taskTodosDAL.GetAllEagerAsync());
        }
    }
}
