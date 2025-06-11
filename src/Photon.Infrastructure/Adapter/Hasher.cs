using Microsoft.AspNetCore.Identity;
using Photon.Infrastructure.Model;


namespace Photon.Infrastructure.Adapter
{
    public class StubUser {}

    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool IsValid(string raw, string hashed);
    }

    public class IdentityPasswordHasher : IPasswordHasher
    {
        private PasswordHasher<StubUser> _passwordHasher = new();

        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(new StubUser(), password);
        }

        public bool IsValid(string raw, string hashed)
        {
            return _passwordHasher.VerifyHashedPassword(new StubUser(), hashed, raw) == PasswordVerificationResult.Success;
        }
    }
}