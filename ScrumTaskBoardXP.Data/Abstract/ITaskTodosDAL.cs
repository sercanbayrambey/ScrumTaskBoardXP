using ScrumTaskBoardXP.Entites.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Data.Abstract
{
    public interface ITaskTodosDAL : IBaseGenericDAL<TaskTodosEntity>
    {
        Task<List<TaskTodosEntity>> GetAllByTaskId(int taskId);
        Task<List<TaskTodosEntity>> GetAllEagerAsync();
    }
}
