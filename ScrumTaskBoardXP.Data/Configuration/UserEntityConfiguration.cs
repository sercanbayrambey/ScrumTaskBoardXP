using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScrumTaskBoardXP.Entites.Concrete;

namespace ScrumTaskBoardXP.Data.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Name).HasMaxLength(100);
            builder.Property(I => I.Email).HasMaxLength(100);
        }
    }
}
