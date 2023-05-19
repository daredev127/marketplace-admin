namespace Marketplace.Admin.Application.Common
{
    public class AppSettings
    {
        public TokenConfigurations TokenConfiguration { get; set; }
        public SalesHistoryApiConfigurations SalesHistoryConfig { get; set; }

        public class TokenConfigurations
        {
            public string Secret { get; set; }
        }

        public class SalesHistoryApiConfigurations
        {
            public string Url { get; set; }
        }
    }
}
