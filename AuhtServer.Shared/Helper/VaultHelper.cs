using AuhtServer.Shared.Configurations;
using Microsoft.Extensions.Options;
using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.Commons;

namespace AuhtServer.Shared.Helper;

public class VaultHelper
{
    private readonly AppSettings _vaultSettings;
    public VaultHelper(IOptions<AppSettings> vaultSettings)
    {
        _vaultSettings = vaultSettings.Value;
    }
    public async Task<Secret<SecretData>> GetVaultKeys()
    {
        string token = Environment.GetEnvironmentVariable("VAULT_TOKEN") ?? throw new Exception("Vault token not found in environment variables");
        string vaultUri = _vaultSettings.VaultUri ?? throw new Exception("Vault URI not found");
        string secretPath = _vaultSettings.SecretPath ?? throw new Exception("Vault secret path not found");
        string mountPoint = _vaultSettings.MountPoint ?? throw new Exception("Vault mount point not found");

        IAuthMethodInfo authMethod = new TokenAuthMethodInfo(token);
        var vaultClientSettings = new VaultClientSettings(vaultUri, authMethod);
        IVaultClient vaultClient = new VaultClient(vaultClientSettings);

        return await vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(path: secretPath, mountPoint: mountPoint);
    }
}
