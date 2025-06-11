using Photon.Application.User.Handler;
using Photon.Domain.Data;
using Photon.Domain.Repository;
using Photon.Infrastructure.Adapter;
using Photon.Infrastructure.Repository;

namespace Photon.Infrastructure.Service
{
    public class RegisterUser(IUserRepo repo, IUoW uow, AuthUserRepo authUserRepo, IPasswordHasher passwordHasher)
    {
        public async Task<Guid> HandleAsync(AuthUserCredentials data)
        {
            var authProvider = new SimpleAuthProvider(data, authUserRepo, passwordHasher);
            var handler = new CreateUser(repo, uow, authProvider);
            return await handler.HandleAsync(new Application.User.CreateUserDto { Username = data.Username });
        }
    }
}