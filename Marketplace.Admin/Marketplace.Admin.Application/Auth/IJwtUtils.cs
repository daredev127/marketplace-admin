namespace Marketplace.Admin.Application.Auth
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(string userId);
        public int? ValidateJwtToken(string? token);
    }
}
