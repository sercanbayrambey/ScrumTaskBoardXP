using ScrumTaskBoardXP.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Web.Models
{
    public class TasksViewModel
    {
        public List<TaskDto> TodoTasks{ get; set; }
        public List<TaskDto> InProgressTasks { get; set; }
        public List<TaskDto> InReviewTasks { get; set; }
        public List<TaskDto> DoneTasks { get; set; }
        public TaskDto TaskDto { get; set; }
    }
}
