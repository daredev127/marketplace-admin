namespace Marketplace.Admin.Application.Auth
{
    public interface IPasswordUtils
    {
        public string GenerateHash(string password);
        bool Validate(string passwordHash, string password);
    }
}
