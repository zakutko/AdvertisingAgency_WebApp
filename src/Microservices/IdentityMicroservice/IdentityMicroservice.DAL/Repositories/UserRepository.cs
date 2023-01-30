using AdvertisingAgency.Constants;
using Dapper;
using IdentityMicroservice.DAL.DataContext;
using IdentityMicroservice.DAL.Interfaces;
using IdentityMicroservice.DAL.Models;
using System.Data;

namespace IdentityMicroservice.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<User>(IdentityServiceConstants.queryGetUserByEmail, new { email = email });
        }

        public async Task<User> GetUserByUsername(string username)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<User>(IdentityServiceConstants.queryGetUserByUsername, new { username = username });
        }

        public async Task<User> GetUserByEmailOrUsername(string username, string email)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<User>(IdentityServiceConstants.queryGetUserByEmailOrUsername, new { username = username, email = email });
        }

        public async Task<User> GetUserByLoginRequest(string usernameOrEmail)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<User>(IdentityServiceConstants.queryGetUserByLoginRequest, new { usernameOfEmail = usernameOrEmail });
        }

        public async Task<User> InsertNewUser(Guid id, string username, DateTime birthday, string email, string passwordHash, string aboutInfo, int roleId)
        {
            using var connection = _context.CreateConnection();
            var newUserId = await connection.QueryFirstOrDefaultAsync<Guid>(IdentityServiceConstants.queryInsertNewUser,
                new
                {
                    id = id,
                    username = username,
                    birthday = birthday,
                    email = email,
                    passwordHash = passwordHash,
                    aboutInfo = aboutInfo,
                    roleId = roleId
                });

            return await connection.QueryFirstOrDefaultAsync<User>(IdentityServiceConstants.queryGetUserById, new { id = newUserId });
        }

        public async Task<User> GetUserById(string id)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<User>(IdentityServiceConstants.queryGetUserById, new { id = id });
        }

        public async Task<IEnumerable<User>> GetAllUsersWithoutCurrUser(string id)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<User>(IdentityServiceConstants.queryGetAllUserWithoutCurrUser, new { id = id });
        }

        public async Task<string> GetUsernameByUserId(string userId)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<string>(IdentityServiceConstants.queryGetUsernameByUserId, new { userId = userId });
        }

        public async Task DeleteUserByUsernameAndEmail(string username, string email)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync("deleteUser", new { username = username, email = email }, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateRoleId(string userId, string roleName)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(IdentityServiceConstants.queryUpdateRoleId, new { userId = userId, roleName = roleName });
        }
    }
}
