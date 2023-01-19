using IdentityMicroservice.BLL.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace IdentityMicroservice.BLL.Helpers
{
    public class IdentityServiceHelper : IIdentityServiceHelper
    {
        public string HashPassword(string password)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
        }

        public string UnHashPassword(string passwordHash)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(passwordHash));
        }

        public string GetUsernameByDecodingJwtToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var username = jwtSecurityToken.Claims.First(claim => claim.Type == "unique_name").Value;

            return username;
        }
    }
}
