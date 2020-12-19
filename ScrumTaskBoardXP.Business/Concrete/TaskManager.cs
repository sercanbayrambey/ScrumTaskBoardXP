using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Data.Abstract;
using ScrumTaskBoardXP.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Business.Concrete
{
    public class TaskManager : GenericManager<TaskEntity>, ITaskService
    {
        private readonly ITaskDAL _taskDAL;
        public TaskManager(ITaskDAL taskDAL) : base(taskDAL)
        {
            _taskDAL = taskDAL;
        }
    }
}
