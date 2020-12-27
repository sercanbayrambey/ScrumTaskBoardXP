using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScrumTaskBoardXP.Entites.Concrete;

namespace ScrumTaskBoardXP.Data.Configuration
{
    public class TaskEntityConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Name).HasMaxLength(200);
            builder.HasOne(I => I.User).WithMany(I => I.Tasks).HasForeignKey(I => I.UserId);
        }
    }
}
