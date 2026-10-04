using System.IdentityModel.Tokens.Jwt;

namespace English_QA.Models.DTO
{
    public class LoginDTO
    {
        public long Id { get; set; }
        public string jwtToken { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;


    }
}
