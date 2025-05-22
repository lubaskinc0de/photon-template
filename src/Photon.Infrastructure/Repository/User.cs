using Photon.Domain.Entity;
using Photon.Domain.Repository;
using Photon.Infrastructure.Data;
using Photon.Infrastructure.Model;

namespace Photon.Infrastructure.Repository
{
    public class UserRepo(ApplicationDbContext context) : IUserRepo
    {
        public async Task AddAsync(User user)
        {
            await context.Users.AddAsync(user);
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await context.Users.FindAsync(id);
        }
    }

    public class AuthUserRepo(ApplicationDbContext context)
    {
        public async Task AddAsync(AuthUser user)
        {
            await context.AuthUsers.AddAsync(user);
        }
    }
}