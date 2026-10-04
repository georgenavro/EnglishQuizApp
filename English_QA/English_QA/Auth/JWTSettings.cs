namespace English_QA.Auth
{
    public class JWTSettings
    {
        public static string Audience {  get; set; } = string.Empty;
        public static string Issuer { get; set; } = string.Empty;
        public static string SecurityKey { get; set; } = string.Empty;  
    }
}
