using ScrumTaskBoardXP.Entites.Abstract;
using System.Collections.Generic;

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
