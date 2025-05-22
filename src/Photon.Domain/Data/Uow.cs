namespace Photon.Domain.Data
{
    public interface IUoW
    {
        Task CommitAsync();
    }
}