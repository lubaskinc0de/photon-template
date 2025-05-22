using Photon.Domain.Data;
using Photon.Domain.Repository;

namespace Photon.Application.User.Handler
{
    public class CreateUser(IUserRepo repo, IUoW uow)
    {
        public async Task<Guid> Handle(CreateUserDto data)
        {
            var user = new Domain.Entity.User(data.Username);
            await repo.AddAsync(user);
            await uow.CommitAsync();
            return user.Id;
        }
    }
}

