using ScrumTaskBoardXP.Entites.Enums;
using System;
using System.Collections.Generic;
using System.Text;


namespace ScrumTaskBoardXP.Entites.Concrete
{
    public class TaskTodosEntity : EntityBase<int>
    {
        public TaskTodoStatus Status { get; set; }
        public string Description { get; set; }
        public TaskEntity Task { get; set; }
        public int TaskId { get; set; }

    }
}