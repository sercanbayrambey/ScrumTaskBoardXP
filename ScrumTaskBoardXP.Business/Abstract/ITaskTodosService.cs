using ScrumTaskBoardXP.Business.Results;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using ScrumTaskBoardXP.Entites.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Business.Abstract
{
    public interface ITaskTodosService : IGenericService<TaskTodosEntity>
    {
        Task<List<TaskTodosDto>> GetAllByTaskId(int taskId);
        Task<List<TaskTodosDto>> GetAllEagerAsync();
        Task<IResult> ChangeTaskState(int taskId, TaskTodoStatus newStatus);
    }
}
