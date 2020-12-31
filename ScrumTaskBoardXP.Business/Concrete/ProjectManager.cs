using AutoMapper;
using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Business.Results;
using ScrumTaskBoardXP.Data.Abstract;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using ScrumTaskBoardXP.Entites.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Business.Concrete
{
    public class ProjectManager : GenericManager<ProjectEntity>, IProjectService
    {
        private readonly ITaskDAL _taskDAL;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public ProjectManager(ITaskDAL taskDAL, IMapper mapper, IUserService userService) : base(taskDAL)
        {
            _taskDAL = taskDAL;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<DateTime> CalculateEstimatedTime(DateTime startedDate, UserEntity userEntity)
        {
            return startedDate.AddHours(((double)200 / userEntity.HourlyWorkRate) + GetUserActiveTaskCount(userEntity).Result * 20);
        }

        public async Task<IResult> ChangeTaskState(int taskId, ProjectStatus newStatus)
        {
            var taskToChange = GetById(taskId);

            if (taskToChange == null)
                return new ErrorResult();

            taskToChange.Status = newStatus;
            Update(taskToChange);

            return new Result();
        }

        public async Task<List<ProjectDto>> GetAllEagerAsync()
        {
            return _mapper.Map<List<ProjectDto>>(await _taskDAL.GetAllEagerAsync());
        }
        public override void Add(ProjectEntity table)
        {
            if (table.UserId != null)
            {
                var taskUser = _userService.GetById(table.UserId.Value);
                if (taskUser == null)
                    return;
                var estimatedTime = CalculateEstimatedTime(table.DateAdded, taskUser).Result;
                table.EstimatedTime = estimatedTime;
            }


            base.Add(table);
        }
        public override void Update(ProjectEntity table)
        {
            if (table.Status == ProjectStatus.Done && table.ActualTime == null)
                table.ActualTime = DateTime.Now;

            base.Update(table);
        }

        public async Task<int> GetUserActiveTaskCount(UserEntity userEntity)
        {
            if (userEntity == null)
                return 0;
            return await _taskDAL.GetUserActiveTaskCount(userEntity);
        }
    }
}
