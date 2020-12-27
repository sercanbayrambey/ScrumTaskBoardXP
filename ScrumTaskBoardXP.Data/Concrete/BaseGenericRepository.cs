using ScrumTaskBoardXP.Data.Abstract;
using ScrumTaskBoardXP.Entites.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ScrumTaskBoardXP.Data.Concrete
{
    public class BaseGenericRepository<T> : IBaseGenericDAL<T> where T : class, IEntity, new()
    {

        public void Add(T table)
        {
            using var context = new ScrumTaskBoardXPDBContext();
            context.Set<T>().Add(table);
            context.SaveChanges();
        }

        public void Delete(T table)
        {
            using var context = new ScrumTaskBoardXPDBContext();
            context.Set<T>().Remove(table);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var context = new ScrumTaskBoardXPDBContext();
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            using var context = new ScrumTaskBoardXPDBContext();
            return context.Set<T>().Find(id);
        }

        public void Update(T table)
        {
            using var context = new ScrumTaskBoardXPDBContext();
            context.Set<T>().Update(table);
            context.SaveChanges();
        }
    }
}
