namespace Photon.Domain.Entity
{
    public class User(string username)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Username { get; private set; } = username;
    }
}