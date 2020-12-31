using ScrumTaskBoardXP.Entites.Enums;
using System;
using System.Collections.Generic;

namespace ScrumTaskBoardXP.Entites.Concrete
{
    public class ProjectEntity : EntityBase<int>
    {

        public string Name { get; set; }
        public DateTime? EstimatedTime { get; set; }
        public DateTime? ActualTime { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public ProjectStatus Status { get; set; }
        public ICollection<TaskTodosEntity> TaskTodos { get; set; }
        public UserEntity User { get; set; }
        public int? UserId { get; set; }


        public ProjectEntity()
        {
            Status = ProjectStatus.Todo;
        }


    }
}
