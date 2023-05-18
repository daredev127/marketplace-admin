using Marketplace.Admin.Domain.Entities.Common;
using System.Text.Json.Serialization;

namespace Marketplace.Admin.Domain.Entities
{
    public class UserBase : EntityBase
    {
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
    }
}
