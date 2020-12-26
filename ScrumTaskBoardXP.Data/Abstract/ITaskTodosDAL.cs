using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Data.Abstract
{
    public interface ITaskTodosDAL : IBaseGenericDAL<TaskTodosEntity>
    {
        Task<List<TaskTodosEntity>> GetAllByTaskId(int taskId);
    }
}
