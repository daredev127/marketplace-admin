namespace Marketplace.Admin.Application.Common
{
    public class AppSettings
    {
        public TokenConfigurations TokenConfiguration { get; set; }

        public string? Secret { get; set; }
        public class TokenConfigurations
        {
            public string Secret { get; set; }
        }
    }
}
