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

        public async Task<Guid> AddBannerAndGetBannerId(string title, string subtitle, string description, string linkToBrowserPage, string photoUrl)
        {
            using var connection = _context.CreateConnection();
            var result = await connection.QueryFirstOrDefaultAsync<Guid>(AdvertisementsServiceConstants.queryAddbannerAdnReturnBannerId,
                new
                {
                    title = title,
                    subtitle = subtitle,
                    description = description,
                    linkToBrowserPage = linkToBrowserPage,
                    photoUrl = photoUrl
                });
            return result;
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

        public async Task<Banner> GetBannerByIdWhereToQueueToCheck(string id)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Banner>(AdvertisementsServiceConstants.queryGetBannerByIdAndStatusInQueueToCheck, new { id = id });
        }

        public async Task<Banner> GetBannerByIdWhereCheckSuccessful(string id)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Banner>(AdvertisementsServiceConstants.queryGetBannerByIdAndStatusCheckSuccessful, new { id = id });
        }

        public async Task<Banner> GetBannerByIdAnyStatus(string id)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Banner>(AdvertisementsServiceConstants.queryGetBannerByIdAnyStatus, new { id = id });
        }

        public async Task AddBannerToQueueToCheck(string bannerId)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(AdvertisementsServiceConstants.queryUpdateBannerAddToQueueToCheck, new { bannerId = bannerId });
        }

        public async Task SetStatusCheckSuccessful(string bannerId)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(AdvertisementsServiceConstants.querySetStatusCheckSuccessful, new { bannerId = bannerId });
        }

        public async Task SetStatusCheckNotSuccessful(string bannerId, string comment)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(AdvertisementsServiceConstants.querySetStatusCheckNotSuccessful, new { bannerId = bannerId, comment = comment });
        }

        public async Task SetStatusReleased(string bannerId)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(AdvertisementsServiceConstants.querySetStatusReleased, new { bannerId = bannerId, releaseDate = DateTime.UtcNow });
        }

        public async Task SetStatusReleasePlanned(string bannerId, DateTime releaseDate)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(AdvertisementsServiceConstants.querySetStatusReleasePlanned, new { bannerId = bannerId, releaseDate = releaseDate });
        }

        public async Task UpdateBanner(string bannerId, string title, string subTitle, string description, string linkToBrowserPage, string photoUrl)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(AdvertisementsServiceConstants.queryUpdateBannerById, 
                new
                {
                    bannerId = Guid.Parse(bannerId),
                    title = title,
                    subTitle = subTitle,
                    description = description,
                    linkToBrowserPage = linkToBrowserPage,
                    photoUrl = photoUrl
                });
        }
    }
}