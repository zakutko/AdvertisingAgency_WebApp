using AdvertisementsMicroservice.DAL.DataContext;
using AdvertisementsMicroservice.DAL.Interfaces;
using AdvertisementsMicroservice.DAL.Models;
using AdvertisingAgency.Constants;
using Dapper;

namespace AdvertisementsMicroservice.DAL.Repositories
{
    public class UserBannerRepository : IUserBannerRepository
    {
        private readonly DapperContext _context;

        public UserBannerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserBanner>> GetAllUserBanners()
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UserBanner>(AdvertisementsServiceConstants.queryGetAllUserBanners);
        }
    }
}
