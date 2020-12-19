using ScrumTaskBoardXP.Data.Abstract;
using ScrumTaskBoardXP.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Data.Concrete
{
    public class TaskTodoRepository : BaseGenericRepository<TaskTodosEntity>, ITaskTodosDAL
    {
    }
}
