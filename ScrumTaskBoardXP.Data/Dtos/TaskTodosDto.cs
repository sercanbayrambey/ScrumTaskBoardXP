using ScrumTaskBoardXP.Entites.Concrete;
using ScrumTaskBoardXP.Entites.Enums;
using System;

namespace ScrumTaskBoardXP.Data.Dtos
{
    public class TaskTodosDto
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public TaskTodoStatus Status { get; set; }
        public string Description { get; set; }
        public int TaskId { get; set; }
        public string Name { get; set; }
        public ProjectEntity Task{ get; set; }

        public TaskTodosDto()
        {
            DateAdded = DateTime.Now;
            Status = TaskTodoStatus.InProgress;
        }
    }
}
