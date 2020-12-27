using ScrumTaskBoardXP.Entites.Concrete;
using ScrumTaskBoardXP.Entites.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Data.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Name { get; set; }
        public DateTime? EstimatedTime { get; set; }
        public DateTime? ActualTime { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public EntityTaskStatus Status { get; set; }
        public ICollection<TaskTodosEntity> TaskTodos { get; set; }
        public UserEntity User { get; set; }
        public int? UserId { get; set; }

    }
}
