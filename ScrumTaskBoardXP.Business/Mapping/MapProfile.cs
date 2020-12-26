using AutoMapper;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<TaskEntity, TaskDto>().ReverseMap();
            CreateMap<TaskTodosEntity, TaskTodosDto>().ReverseMap();
        }
    }
}
