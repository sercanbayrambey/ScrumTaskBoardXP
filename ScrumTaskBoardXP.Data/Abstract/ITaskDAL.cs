using ScrumTaskBoardXP.Entites.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Data.Abstract
{
    public interface ITaskDAL : IBaseGenericDAL<TaskEntity>
    {
        Task<List<TaskEntity>> GetAllWithUser();
        Task<int> GetUserActiveTaskCount(UserEntity userEntity);
    }
}
