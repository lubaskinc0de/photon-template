using System.ComponentModel.DataAnnotations;
using Photon.Application.Common;
using Photon.Domain.Entity;
using Photon.Infrastructure.Model;
using Photon.Infrastructure.Repository;

namespace Photon.Infrastructure.Adapter
{
    public class AuthUserCredentials
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public required string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        public required string Password { get; set; }
    };

    public class SimpleAuthProvider : IAuthProvider
    {
        private readonly AuthUserCredentials _credentials;
        private readonly AuthUserRepo _repo;
        private readonly IPasswordHasher _passwordHasher;

        public SimpleAuthProvider(AuthUserCredentials credentials, AuthUserRepo repo, IPasswordHasher passwordHasher)
        {
            _credentials = credentials;
            _repo = repo;
            _passwordHasher = passwordHasher;
        }

        public async Task BindIdentityAsync(User user)
        {
            var authUser = new AuthUser(_credentials.Username, _passwordHasher.HashPassword(_credentials.Password))
            {
                User = user,
            };
            await _repo.AddAsync(authUser);
        }
    }
}

