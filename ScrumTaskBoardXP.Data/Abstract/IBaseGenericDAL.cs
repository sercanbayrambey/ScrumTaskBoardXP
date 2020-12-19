using ScrumTaskBoardXP.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Data.Abstract
{
    public interface IBaseGenericDAL<T> where T: class, IEntity, new()
    {
        void Add(T table);
        void Delete(T table);
        void Update(T table);
        List<T> GetAll();
        T GetById(int id);
    }
}
