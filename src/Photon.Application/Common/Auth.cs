namespace Photon.Application.Common {
    public interface IAuthProvider {
        Task BindIdentityAsync(Domain.Entity.User user);
    }
}