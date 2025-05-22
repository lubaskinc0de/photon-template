using Photon.Application.Common;
using Photon.Domain.Entity;
using Photon.Infrastructure.Model;
using Photon.Infrastructure.Repository;

namespace Photon.Infrastructure.Adapter
{
    public record AuthUserCredentials(string Username, string HashedPassword);

    public class SimpleAuthProvider : IAuthProvider
    {
        private readonly AuthUserCredentials _credentials;
        private readonly AuthUserRepo _repo;

        SimpleAuthProvider(AuthUserCredentials credentials, AuthUserRepo repo)
        {
            _credentials = credentials;
            _repo = repo;
        }

        public async Task BindIdentityAsync(User user)
        {
            var authUser = new AuthUser(_credentials.Username, _credentials.HashedPassword)
            {
                User = user,
            };
            await _repo.AddAsync(authUser);
        }
    }
}

