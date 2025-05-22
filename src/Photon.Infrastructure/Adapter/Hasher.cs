using Microsoft.AspNetCore.Identity;
using Photon.Infrastructure.Migrations;


namespace Photon.Infrastructure.Adapter
{
    public interface IPasswordHasher
    {
        string HashPassword(AuthUser user, string password);
        bool IsValid(AuthUser user, string raw, string hashed);
    }

    public class IdentityPasswordHasher : IPasswordHasher
    {
        private PasswordHasher<AuthUser> _passwordHasher = new();

        public string HashPassword(AuthUser user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public bool IsValid(AuthUser user, string raw, string hashed)
        {
            return _passwordHasher.VerifyHashedPassword(user, hashed, raw) == PasswordVerificationResult.Success;
        }
    }
}