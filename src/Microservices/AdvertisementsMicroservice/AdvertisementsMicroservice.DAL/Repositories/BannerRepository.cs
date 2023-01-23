using AdvertisementsMicroservice.DAL.DataContext;
using AdvertisementsMicroservice.DAL.Interfaces;
using AdvertisementsMicroservice.DAL.Models;
using AdvertisingAgency.Constants;
using Dapper;

namespace AdvertisementsMicroservice.DAL.Repositories
{
    public class BannerRepository : IBannerRepository
    {
        private readonly DapperContext _context;

        public BannerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Banner>> GetAllBanners()
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Banner>(AdvertisementsServiceConstants.queryGetAllBanners);
        }

        public async Task<Banner> GetBannerById(string id)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Banner>(AdvertisementsServiceConstants.queryGetBannerById, new { id = id });
        }
    }
}
