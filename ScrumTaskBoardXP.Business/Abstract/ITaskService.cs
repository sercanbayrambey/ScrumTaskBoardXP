using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using ScrumTaskBoardXP.Entites.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Business.Abstract
{
    public interface ITaskService : IGenericService<TaskEntity>
    {
        Task ChangeTaskState(int taskId, EntityTaskStatus newStatus);
        Task<List<TaskDto>> GetAllWithUser();
    }
}
