using ScrumTaskBoardXP.Entites.Enums;


namespace ScrumTaskBoardXP.Entites.Concrete
{
    public class TaskTodosEntity : EntityBase<int>
    {
        public TaskTodoStatus Status { get; set; }
        public string Description { get; set; }
        public ProjectEntity Task { get; set; }
        public int TaskId { get; set; }
        public string Name { get; set; }

    }
}