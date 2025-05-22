using Microsoft.EntityFrameworkCore;
using Photon.Domain.Data;
using Photon.Domain.Entity;
using Photon.Infrastructure.Model;

namespace Photon.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<AuthUser> AuthUsers => Set<AuthUser>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AuthUser>(entity =>
            {
                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Username).HasMaxLength(50).IsRequired();
            });
        }
    }

    public class UoW(ApplicationDbContext context) : IUoW
    {
        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}