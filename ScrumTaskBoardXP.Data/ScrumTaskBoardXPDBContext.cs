﻿using Microsoft.EntityFrameworkCore;
using ScrumTaskBoardXP.Data.Configuration;
using ScrumTaskBoardXP.Entites.Concrete;

namespace ScrumTaskBoardXP.Data
{
    public class ScrumTaskBoardXPDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SERCAN;Database=ScrumTaskBoardXP;Integrated Security=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskTodosEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }

        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<TaskTodosEntity> TasksTodos { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
