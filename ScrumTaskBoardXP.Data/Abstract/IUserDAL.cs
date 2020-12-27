using ScrumTaskBoardXP.Entites.Concrete;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Data.Abstract
{
    public interface IUserDAL : IBaseGenericDAL<UserEntity>
    {
        Task<UserEntity> GetUser(string email, string passwordSha1);
        Task<UserEntity> GetByEmail(string email);
    }
}
