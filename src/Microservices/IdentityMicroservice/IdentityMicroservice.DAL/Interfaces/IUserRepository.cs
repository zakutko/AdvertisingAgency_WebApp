using IdentityMicroservice.DAL.Models;

namespace IdentityMicroservice.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserByEmailOrUsername(string email, string username);
        Task<User> GetUserByLoginRequest(string usernameOrEmail);
        Task<User> InsertNewUser(Guid id, string username, DateTime birthday, string email, string passwordHash, string aboutInfo, int roleId);
        Task<User> GetUserById(string id);
        Task<IEnumerable<User>> GetAllUsersWithoutCurrUser(string id);
        Task<string> GetUsernameByUserId(string userId);
        Task DeleteUserByUsernameAndEmail(string username, string email);
        Task UpdateRoleId(string userId, string roleName);
    }
}
