using IdentityMicroservice.BLL.Interfaces;
using IdentityMicroservice.DAL.Models;
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

        public int GetAgeByBirthday(DateTime birthday)
        {
            var dateTimeNow = DateTime.UtcNow;
            var difference = dateTimeNow.Subtract(birthday);
            var firstDay = new DateTime(1, 1, 1);
            return (firstDay + difference).Year - 1;
        }
    }
}
