using ScrumTaskBoardXP.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

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
