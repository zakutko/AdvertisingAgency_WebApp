using AdvertisementsMicroservice.DAL.Models;

namespace AdvertisementsMicroservice.DAL.Interfaces
{
    public interface IUserBannerRepository
    {
        Task<IEnumerable<UserBanner>> GetAllUserBanners();
    }
}
