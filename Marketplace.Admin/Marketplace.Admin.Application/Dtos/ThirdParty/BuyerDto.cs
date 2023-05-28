namespace Marketplace.Admin.Application.Dtos.ThirdParty
{
    public class BuyerDto
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string State { get; set; } = "Unknown Location";
    }
}
