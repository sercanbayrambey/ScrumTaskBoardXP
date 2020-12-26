using ScrumTaskBoardXP.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Data.Abstract
{
    public interface ITaskDAL : IBaseGenericDAL<TaskEntity>
    {
        Task<List<TaskEntity>> GetAllWithUser();
    }
}
