using ScrumTaskBoardXP.Entites.Enums;
using System;
using System.Collections.Generic;
using System.Text;

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

        public TaskTodosDto()
        {
            DateAdded = DateTime.Now;
            Status = TaskTodoStatus.InProgress;
        }
    }
}
