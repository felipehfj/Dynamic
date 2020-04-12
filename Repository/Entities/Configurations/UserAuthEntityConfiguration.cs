using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Entities.Configurations
{
    public class UserAuthEntityConfiguration : BaseEntityTypeConfiguration<UserAuth>
    {
        public override void Configure(EntityTypeBuilder<UserAuth> builder)
        {
            builder.Property(e => e.Password)
            .IsUnicode()
            .HasMaxLength(255)
            .IsRequired();

            builder.Property(e => e.IsActive)
            .IsRequired()
            .HasDefaultValueSql("((1))");

            builder.HasOne(d => d.User)
                .WithMany(p => p.UserAuths)
                .HasForeignKey(f => f.UserId)
                ;

            base.Configure(builder);
        }
    }
}
