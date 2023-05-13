namespace Marketplace.Admin.Domain.Repositories
{
    public interface IAdminRepository
    {
        Task<bool> Authenticate(string username, string password);
    }
}
