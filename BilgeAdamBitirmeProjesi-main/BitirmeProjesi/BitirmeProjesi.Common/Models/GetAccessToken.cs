namespace BitirmeProjesi.Common.Models
{
    public class GetAccessToken
    {
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public long Expires { get; set; }
        public string RefreshToken { get; set; }
    }
}
