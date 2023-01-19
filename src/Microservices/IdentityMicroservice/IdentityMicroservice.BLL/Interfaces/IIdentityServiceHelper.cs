namespace IdentityMicroservice.BLL.Interfaces
{
    public interface IIdentityServiceHelper
    {
        string HashPassword(string password);
        string GetUsernameByDecodingJwtToken(string token);
    }
}
