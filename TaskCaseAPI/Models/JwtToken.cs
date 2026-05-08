namespace TaskCaseAPI.Models
{
    public class JwtToken
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}
