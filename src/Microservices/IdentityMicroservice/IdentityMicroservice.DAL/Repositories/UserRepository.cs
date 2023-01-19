using AdvertisingAgency.Constants;
using Dapper;
using IdentityMicroservice.DAL.DataContext;
using IdentityMicroservice.DAL.Interfaces;
using IdentityMicroservice.DAL.Models;

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

        public async Task<User> InsertNewUser(Guid id, string username, int age, string email, string passwordHash, string aboutInfo, int roleId)
        {
            using var connection = _context.CreateConnection();
            var newUserId = await connection.QueryFirstOrDefaultAsync<Guid>(IdentityServiceConstants.queryInsertNewUser,
                new
                {
                    id = id,
                    username = username,
                    age = age,
                    email = email,
                    passwordHash = passwordHash,
                    aboutInfo = aboutInfo,
                    roleId = roleId
                });

            return await connection.QueryFirstOrDefaultAsync<User>(IdentityServiceConstants.queryGetUserById, new { id = newUserId });
        }
    }
}
