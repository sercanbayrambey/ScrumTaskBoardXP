using ScrumTaskBoardXP.Entites.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Data.Abstract
{
    public interface ITaskDAL : IBaseGenericDAL<ProjectEntity>
    {
        Task<List<ProjectEntity>> GetAllEagerAsync();
        Task<int> GetUserActiveTaskCount(UserEntity userEntity);
    }
}
