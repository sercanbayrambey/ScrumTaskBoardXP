using Microsoft.EntityFrameworkCore;
using ScrumTaskBoardXP.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Data
{
    public class ScrumTaskBoardXPDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SERCAN;Database=SB.B3DTournamentSystem;Integrated Security=true;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<TaskEntity> Tasks{ get; set; }

    }
}
