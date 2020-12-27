using AutoMapper;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;

namespace ScrumTaskBoardXP.Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<TaskEntity, TaskDto>();
            CreateMap<TaskDto, TaskEntity>().ForMember(x => x.ActualTime, opt => opt.Ignore()).ForMember(x => x.DateAdded, opt => opt.Ignore()).ForMember(x => x.EstimatedTime, opt => opt.Ignore()).ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<TaskTodosEntity, TaskTodosDto>();
            CreateMap<TaskTodosDto, TaskTodosEntity>().ForMember(x => x.DateAdded, opt => opt.Ignore());
            CreateMap<UserEntity, UserDto>().ReverseMap();
        }
    }
}
