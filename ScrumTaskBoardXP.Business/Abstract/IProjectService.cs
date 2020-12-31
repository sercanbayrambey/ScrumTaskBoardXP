using ScrumTaskBoardXP.Business.Results;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using ScrumTaskBoardXP.Entites.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Business.Abstract
{
    public interface IProjectService : IGenericService<ProjectEntity>
    {
        Task<IResult> ChangeTaskState(int taskId, ProjectStatus newStatus);
        Task<List<ProjectDto>> GetAllEagerAsync();
        Task<DateTime> CalculateEstimatedTime(DateTime startedDate, UserEntity userEntity);

        Task<int> GetUserActiveTaskCount(UserEntity userEntity);

    }
}
