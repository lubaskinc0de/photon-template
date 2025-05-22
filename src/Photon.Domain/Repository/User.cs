using Photon.Domain.Entity;

namespace Photon.Domain.Repository
{
    public interface IUserRepo
    {
        Task<User?> GetByIdAsync(Guid id);
        Task AddAsync(User user);
    }
}