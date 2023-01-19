using IdentityMicroservice.DAL.Models;

namespace IdentityMicroservice.BLL.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
