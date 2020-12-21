using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScrumTaskBoardXP.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Data.Configuration
{
    public class TaskTodosEntityConfiguration : IEntityTypeConfiguration<TaskTodosEntity>
    {
        public void Configure(EntityTypeBuilder<TaskTodosEntity> builder)
        {
            builder.HasKey(I => I.Id);
            builder.HasOne(I => I.Task).WithMany(I => I.TaskTodos).HasForeignKey(I => I.TaskId);
            builder.Property(I => I.Name).HasMaxLength(64);
        }
    }
}
