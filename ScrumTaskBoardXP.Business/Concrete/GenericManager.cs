using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Data.Abstract;
using ScrumTaskBoardXP.Entites.Abstract;
using System.Collections.Generic;

namespace ScrumTaskBoardXP.Business.Concrete
{
    public class GenericManager<EntityTable> : IGenericService<EntityTable> where EntityTable : class, IEntity, new()
    {

        private readonly IBaseGenericDAL<EntityTable> _entityDAL;
        public GenericManager(IBaseGenericDAL<EntityTable> entityDAL)
        {
            _entityDAL = entityDAL;
        }
        public virtual void Add(EntityTable table)
        {
            _entityDAL.Add(table);
        }

        public void Delete(EntityTable table)
        {
            _entityDAL.Delete(table);
        }

        public List<EntityTable> GetAll()
        {
            return _entityDAL.GetAll();
        }

        public EntityTable GetById(int id)
        {
            return _entityDAL.GetById(id);
        }

        public virtual void Update(EntityTable table)
        {
            _entityDAL.Update(table);
        }
    }
}
