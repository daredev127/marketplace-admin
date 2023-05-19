namespace Marketplace.Admin.Application.Features.Auth
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(string userId);
        public int? ValidateJwtToken(string? token);
    }
}
