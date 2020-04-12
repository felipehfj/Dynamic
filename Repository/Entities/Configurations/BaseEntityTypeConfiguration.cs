using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Entities.Configurations
{
    public abstract class BaseEntityTypeConfiguration<TBase> : IEntityTypeConfiguration<TBase>
    where TBase : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            //Base Configuration
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("NEWID()");

            builder.Property(e => e.CreatedAtUtc)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(e => e.UpdatedAtUtc)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
