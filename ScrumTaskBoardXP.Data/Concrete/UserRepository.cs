using Microsoft.EntityFrameworkCore;
using ScrumTaskBoardXP.Data.Abstract;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Data.Concrete
{
    public class UserRepository : BaseGenericRepository<UserEntity>, IUserDAL
    {
        private readonly ScrumTaskBoardXPDBContext _context;

        public UserRepository(ScrumTaskBoardXPDBContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> GetByEmail(string email)
        {
            return await _context.Users.Where(I => I.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<UserEntity> GetUser(string email, string passwordSha1)
        {
            return await _context.Users.Where(I => I.Email.ToLower() == email.ToLower() && I.PasswordSha1 == passwordSha1).FirstOrDefaultAsync();
        }
    }
}
