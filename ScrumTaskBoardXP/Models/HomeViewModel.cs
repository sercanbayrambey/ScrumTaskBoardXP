using ScrumTaskBoardXP.Data.Dtos;
using System.Collections.Generic;

namespace ScrumTaskBoardXP.Web.Models
{
    public class HomeViewModel
    {
        public List<TaskTodosDto> TodoTasks { get; set; }
        public List<TaskTodosDto> InProgressTasks { get; set; }
        public List<TaskTodosDto> InReviewTasks { get; set; }
        public List<TaskTodosDto> DoneTasks { get; set; }
        public ProjectDto TaskDto { get; set; }
        public List<ProjectDto> Projects { get; set; }
    }
}
