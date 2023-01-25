using AdvertisementsMicroservice.DAL.Models;

namespace AdvertisementsMicroservice.DAL.Interfaces
{
    public interface IUserBannerRepository
    {
        Task<IEnumerable<UserBanner>> GetAllUserBanners();
        Task<IEnumerable<UserBanner>> GetAllUserBannersByUserId(Guid userId);
        Task AddUserBanner(string userId, Guid bannerId);
    }
}
