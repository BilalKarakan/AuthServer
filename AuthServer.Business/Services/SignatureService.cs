using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AuthServer.Business.Services;

public static class SignatureService
{
    public static SecurityKey CreateSignature(string securityKey) => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
}
