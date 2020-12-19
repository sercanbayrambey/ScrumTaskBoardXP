using ScrumTaskBoardXP.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Business.Abstract
{
    public interface IGenericService<EntityTable> where EntityTable : class, IEntity, new()
    {
        void Add(EntityTable table);
        void Delete(EntityTable table);
        void Update(EntityTable table);
        List<EntityTable> GetAll();
        EntityTable GetById(int id);
    }
}
