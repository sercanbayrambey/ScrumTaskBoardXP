using Microsoft.EntityFrameworkCore;
using ScrumTaskBoardXP.Data.Abstract;
using ScrumTaskBoardXP.Entites.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Data.Concrete
{
    public class ProjectRepository : BaseGenericRepository<ProjectEntity>, ITaskDAL
    {
        private readonly ScrumTaskBoardXPDBContext _context;

        public ProjectRepository(ScrumTaskBoardXPDBContext context)
        {
            _context = context;
        }
        public async Task<List<ProjectEntity>> GetAllEagerAsync()
        {
            return await _context.Projects.Include(I => I.User).Include(I=>I.TaskTodos).ToListAsync();
        }

        public async Task<int> GetUserActiveTaskCount(UserEntity userEntity)
        {
            var query = _context.Projects.Where(I => I.UserId == userEntity.Id && I.Status != Entites.Enums.ProjectStatus.Done);
            return query.ToList().Count();
        }
    }
}
