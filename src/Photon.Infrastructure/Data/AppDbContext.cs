using Microsoft.EntityFrameworkCore;
using Photon.Domain.Data;
using Photon.Domain.Entity;

namespace Photon.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
    }

    public class UoW(ApplicationDbContext context) : IUoW
    {
        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}