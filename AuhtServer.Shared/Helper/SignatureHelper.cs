using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AuhtServer.Shared.Helper;

public static class SignatureHelper
{
    public static SecurityKey CreateSignature(string securityKey) => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
}
