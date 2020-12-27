using ScrumTaskBoardXP.Entites.Abstract;
using System.Collections.Generic;

namespace ScrumTaskBoardXP.Data.Abstract
{
    public interface IBaseGenericDAL<T> where T : class, IEntity, new()
    {
        void Add(T table);
        void Delete(T table);
        void Update(T table);
        List<T> GetAll();
        T GetById(int id);
    }
}
