using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Entities.Configurations;

namespace Repository.Context
{
    public class DynamicContext : DbContext
    {
        public DynamicContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserAuthEntityConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAuth> UserAuths { get; set; }
    }
}
