using AdvertisingAgency.Constants;
using Dapper;
using IdentityMicroservice.DAL.DataContext;
using IdentityMicroservice.DAL.Interfaces;

namespace IdentityMicroservice.DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DapperContext _context;

        public RoleRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<string> GetRoleNameById(int id)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<string>(IdentityServiceConstants.queryGetRoleNameById, new { id = id });
        }
    }
}
