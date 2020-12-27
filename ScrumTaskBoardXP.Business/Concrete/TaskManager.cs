using AutoMapper;
using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Business.Results;
using ScrumTaskBoardXP.Data.Abstract;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using ScrumTaskBoardXP.Entites.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Business.Concrete
{
    public class TaskManager : GenericManager<TaskEntity>, ITaskService
    {
        private readonly ITaskDAL _taskDAL;
        private readonly IMapper _mapper;
        public TaskManager(ITaskDAL taskDAL, IMapper mapper) : base(taskDAL)
        {
            _taskDAL = taskDAL;
            _mapper = mapper;
        }

        public async Task<IResult> ChangeTaskState(int taskId, EntityTaskStatus newStatus)
        {
            var taskToChange = GetById(taskId);

            if (taskToChange == null)
                return new ErrorResult();

            taskToChange.Status = newStatus;
            Update(taskToChange);
            
            return new Result();
        }

        public async Task<List<TaskDto>> GetAllWithUser()
        {
            return _mapper.Map<List<TaskDto>>(await _taskDAL.GetAllWithUser());
        }
    }
}
