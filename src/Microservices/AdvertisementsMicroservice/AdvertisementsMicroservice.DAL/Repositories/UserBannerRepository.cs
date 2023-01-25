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

        public async Task AddUserBanner(string userId, Guid bannerId)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(AdvertisementsServiceConstants.queryAddUserBanner, new { userId = Guid.Parse(userId), bannerId = bannerId });
        }

        public async Task<IEnumerable<UserBanner>> GetAllUserBanners()
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UserBanner>(AdvertisementsServiceConstants.queryGetAllUserBanners);
        }

        public async Task<IEnumerable<UserBanner>> GetAllUserBannersByUserId(Guid userId)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UserBanner>(AdvertisementsServiceConstants.queryGetAllUserBannersByUserId, new { userId = userId });
        }
    }
}
