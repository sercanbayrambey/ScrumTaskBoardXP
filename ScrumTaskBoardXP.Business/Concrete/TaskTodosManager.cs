using AutoMapper;
using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Data.Abstract;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<List<TaskTodosDto>> GetAllByTaskId(int taskId)
        {
            return _mapper.Map<List<TaskTodosDto>>(await _taskTodosDAL.GetAllByTaskId(taskId));
        }
    }
}
