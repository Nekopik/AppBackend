using System.Text.Json.Serialization;

namespace MvcApp.Classes
{
    public class RefreshTokenRequest
    {
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
