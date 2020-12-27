using ScrumTaskBoardXP.Entites.Abstract;
using System;

namespace ScrumTaskBoardXP.Entites.Concrete
{
    public class EntityBase<T> : IEntity
    {
        public EntityBase()
        {
            DateAdded = DateTime.Now;
        }
        public T Id { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
