using Microsoft.EntityFrameworkCore;
using ScrumTaskBoardXP.Data.Abstract;
using ScrumTaskBoardXP.Entites.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Data.Concrete
{
    public class TaskTodoRepository : BaseGenericRepository<TaskTodosEntity>, ITaskTodosDAL
    {

        private readonly ScrumTaskBoardXPDBContext _context;

        public TaskTodoRepository(ScrumTaskBoardXPDBContext context)
        {
            _context = context;
        }
        public async Task<List<TaskTodosEntity>> GetAllByTaskId(int taskId)
        {
            return await _context.TasksTodos.Where(I => I.TaskId == taskId).ToListAsync();
        }

        public async Task<List<TaskTodosEntity>> GetAllEagerAsync()
        {
            return await _context.TasksTodos.Include(I => I.Task).ThenInclude(I => I.User).ToListAsync();
        }
    }
}
