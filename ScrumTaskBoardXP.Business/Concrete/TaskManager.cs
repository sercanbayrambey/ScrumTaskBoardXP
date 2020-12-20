using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Data.Abstract;
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
        public TaskManager(ITaskDAL taskDAL) : base(taskDAL)
        {
            _taskDAL = taskDAL;
        }

        public async Task ChangeTaskState(int taskId, EntityTaskStatus newStatus)
        {
            var taskToChange = GetById(taskId);
            if (taskToChange == null)
                throw new Exception();
            taskToChange.Status = newStatus;
            Update(taskToChange);


        }

     
    }
}
