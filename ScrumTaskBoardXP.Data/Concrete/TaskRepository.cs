using Microsoft.EntityFrameworkCore;
using ScrumTaskBoardXP.Data.Abstract;
using ScrumTaskBoardXP.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Data.Concrete
{
    public class TaskRepository : BaseGenericRepository<TaskEntity>, ITaskDAL
    {
        private readonly ScrumTaskBoardXPDBContext _context;

        public TaskRepository(ScrumTaskBoardXPDBContext context)
        {
            _context = context;
        }
        public async Task<List<TaskEntity>> GetAllWithUser()
        {
            return await _context.Tasks.Include(I => I.User).ToListAsync();
        }

        public async Task<int> GetUserActiveTaskCount(UserEntity userEntity)
        {
            var query = _context.Tasks.Where(I => I.UserId == userEntity.Id && I.Status != Entites.Enums.EntityTaskStatus.Done);
            return query.ToList().Count();
        }
    }
}
