namespace AuhtServer.Shared.Configurations;

public class AppSettings
{
    public const string AccessTokenExpire = "AccessTokenExpire";
    public const string RefreshTokenExpire = "RefreshTokenExpire";
    public const string SecurityKey = "SecurityKey";
    public const string Issuer = "Issuer";
    public const string Audience = "Audience";
    public const string JWTOption = "JWTOption";
    public string VaultUri { get; set; } = default!;
    public string SecretPath { get; set; } = default!;
    public string MountPoint { get; set; } = default!;
}
