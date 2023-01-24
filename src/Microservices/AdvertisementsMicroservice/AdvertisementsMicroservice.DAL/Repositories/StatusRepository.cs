using AdvertisementsMicroservice.DAL.DataContext;
using AdvertisementsMicroservice.DAL.Interfaces;
using AdvertisingAgency.Constants;
using Dapper;

namespace AdvertisementsMicroservice.DAL.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly DapperContext _context;

        public StatusRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<string> GetStatusNameById(int id)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<string>(AdvertisementsServiceConstants.queryGetStatusNameById, new { id = id });
        }
    }
}
