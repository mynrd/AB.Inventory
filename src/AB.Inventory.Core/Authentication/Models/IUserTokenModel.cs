namespace AB.Inventory.Core.Authentication.Models
{
    public interface IUserTokenModel
    {
        ChangeApiTokenType ChangeApiTokenType { get; set; }
        DateTime Expiration { get; set; }
        string RefreshToken { get; set; }
        string Token { get; set; }
        DateTime ValidFrom { get; set; }
    }

    public class UserTokenModelTemp : IUserTokenModel
    { 
        public ChangeApiTokenType ChangeApiTokenType { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
        public string Token { get; set; }
        public DateTime ValidFrom { get; set; }
    }
}