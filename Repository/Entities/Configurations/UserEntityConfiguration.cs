using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Entities.Configurations
{
    public class UserEntityConfiguration : BaseEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Name)
            .IsUnicode()
            .HasMaxLength(255)
            .IsRequired();

            builder.Property(e => e.ExibitionName)
            .IsUnicode()
            .HasMaxLength(30);

            builder.Property(e => e.Email)
            .IsUnicode()
            .HasMaxLength(255)
            .IsRequired();

            builder.Property(e => e.Login)
            .IsUnicode()
            .HasMaxLength(20)
            .IsRequired();

            builder.HasIndex(e => e.Login)
                .IsUnique();

            base.Configure(builder);
        }
    }
}
