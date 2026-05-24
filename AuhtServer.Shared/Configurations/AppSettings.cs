namespace AuhtServer.Shared.Configurations;

public class AppSettings
{
    public string Token { get; set; } = default!;
    public string VaultUri { get; set; } = default!;
    public string SecretPath { get; set; } = default!;
    public string MountPoint { get; set; } = default!;
}
