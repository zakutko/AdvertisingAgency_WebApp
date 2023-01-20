using IdentityMicroservice.BLL.Interfaces;
using IdentityMicroservice.DAL.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace IdentityMicroservice.BLL.Helpers
{
    public class IdentityServiceHelper : IIdentityServiceHelper
    {
        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hash;
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

        public string GetUserIdByDecodingJwtToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            return jwtSecurityToken.Claims.First(claim => claim.Type == "nameid").Value;
        }

        public int GetAgeByBirthday(DateTime birthday)
        {
            var dateTimeNow = DateTime.UtcNow;
            var difference = dateTimeNow.Subtract(birthday);
            var firstDay = new DateTime(1, 1, 1);
            return (firstDay + difference).Year - 1;
        }
    }
}
