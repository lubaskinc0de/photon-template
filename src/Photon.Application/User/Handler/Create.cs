using Photon.Application.Common;
using Photon.Domain.Data;
using Photon.Domain.Repository;

namespace Photon.Application.User.Handler
{
    public class CreateUser(IUserRepo repo, IUoW uow, IAuthProvider authProvider)
    {
        public async Task<Guid> HandleAsync(CreateUserDto data)
        {
            var user = new Domain.Entity.User(data.Username);

            await repo.AddAsync(user);
            await authProvider.BindIdentityAsync(user);
            await uow.CommitAsync();

            return user.Id;
        }
    }
}

