using ScrumTaskBoardXP.Data.Dtos;
using System.Collections.Generic;

namespace ScrumTaskBoardXP.Web.Models
{
    public class TasksViewModel
    {
        public List<TaskDto> TodoTasks { get; set; }
        public List<TaskDto> InProgressTasks { get; set; }
        public List<TaskDto> InReviewTasks { get; set; }
        public List<TaskDto> DoneTasks { get; set; }
        public TaskDto TaskDto { get; set; }
    }
}
