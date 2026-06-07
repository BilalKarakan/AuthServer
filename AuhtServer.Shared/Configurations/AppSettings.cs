namespace AuhtServer.Shared.Configurations;

public class AppSettings
{
    public const string ConnectionStrings = "ConnectionStrings";
    public const string PostgreConnection = "PostgreConnection";
    public const string AccessTokenExpire = "AccessTokenExpire";
    public const string VaultKeys = "VaultKeys";
    public const string RefreshTokenExpire = "RefreshTokenExpire";
    public const string SecurityKey = "SecurityKey";
    public const string Issuer = "Issuer";
    public const string Audience = "Audience";
    public const string JWTOption = "JWTOption";
    public string VaultUri { get; set; } = default!;
    public string SecretPath { get; set; } = default!;
    public string MountPoint { get; set; } = default!;
}
