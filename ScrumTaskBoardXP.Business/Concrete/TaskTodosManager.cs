using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Data.Abstract;
using ScrumTaskBoardXP.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Business.Concrete
{
    public class TaskTodosManager : GenericManager<TaskTodosEntity>, ITaskTodosService
    {
        private readonly ITaskTodosDAL _taskTodosDAL;

        public TaskTodosManager(ITaskTodosDAL taskTodosDAL) : base(taskTodosDAL)
        {
            _taskTodosDAL = taskTodosDAL;
        }
    }
}
