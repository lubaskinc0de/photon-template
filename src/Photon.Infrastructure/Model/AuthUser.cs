using Photon.Domain.Entity;

namespace Photon.Infrastructure.Model
{
    public class AuthUser(string username, string hashedPassword)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public required User User { get; set; }
        public string Username { get; private set; } = username;
        public string HashedPassword { get; private set; } = hashedPassword;
    }
}