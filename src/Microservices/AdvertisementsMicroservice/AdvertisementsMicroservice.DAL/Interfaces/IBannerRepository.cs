using AdvertisementsMicroservice.DAL.Models;

namespace AdvertisementsMicroservice.DAL.Interfaces
{
    public interface IBannerRepository
    {
        Task<Banner> GetBannerById(string id);
        Task<IEnumerable<Banner>> GetAllBanners();
        Task<Banner> GetBannerByIdWhereStatusRelease(string id);
        Task<Banner> GetBannerByIdWhereToQueueToCheck(string id);
        Task<Banner> GetBannerByIdWhereCheckSuccessful(string id);
        Task<Banner> GetBannerByIdAnyStatus(string id);
        Task<Banner> GetBannerWhereStatusReleasePlanned(string id);
        Task<Guid> AddBannerAndGetBannerId(string title, string subtitle, string description, string linkToBrowserPage, string photoUrl);
        Task AddBannerToQueueToCheck(string bannerId);
        Task SetStatusCheckSuccessful(string bannerId);
        Task SetStatusCheckNotSuccessful(string bannerId, string comment);
        Task SetStatusReleased(string bannerId);
        Task SetStatusReleasePlanned(string bannerId, DateTime releaseDate);
        Task UpdateBanner(string bannerId, string title, string subTitle, string description, string linkToBrowserPage, string photoUrl);
    }
}
