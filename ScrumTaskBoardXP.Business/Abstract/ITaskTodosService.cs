using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Business.Abstract
{
    public interface ITaskTodosService : IGenericService<TaskTodosEntity>
    {
        Task<List<TaskTodosDto>> GetAllByTaskId(int taskId);
    }
}
