using AB.Inventory.Core.Authentication.Models;

namespace AB.Inventory.Application.Authentication.Models
{
    public class UserTokenModel : IUserTokenModel
    {
        public ChangeApiTokenType ChangeApiTokenType { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
        public string Token { get; set; }
        public DateTime ValidFrom { get; set; }
    }
}