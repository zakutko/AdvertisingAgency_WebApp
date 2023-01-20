using AdvertisingAgency.Constants;
using Dapper;
using IdentityMicroservice.DAL.DataContext;
using IdentityMicroservice.DAL.Interfaces;
using IdentityMicroservice.DAL.Models;

namespace IdentityMicroservice.DAL.Repositories
{
    public class RoleRequestRepository : IRoleRequestRepository
    {
        private readonly DapperContext _context;

        public RoleRequestRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<RoleRequest> GetRoleRequestByUserId(string userId)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<RoleRequest>(IdentityServiceConstants.queryGetRoleRequestByUserId, new { userId = userId });
        }

        public async Task InsertNewRoleRequest(string userId, string roleName, int numberOfPublications, bool isOldUser)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(IdentityServiceConstants.queryInsertNewRoleRequest, 
                new
                {
                    userId = userId,
                    roleName = roleName,
                    numberOfPublications = numberOfPublications,
                    isOldUser = isOldUser 
                });
        }
    }
}
