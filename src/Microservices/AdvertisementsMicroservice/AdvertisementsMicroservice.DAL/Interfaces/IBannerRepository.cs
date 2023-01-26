using AdvertisementsMicroservice.DAL.Models;

namespace AdvertisementsMicroservice.DAL.Interfaces
{
    public interface IBannerRepository
    {
        Task<IEnumerable<Banner>> GetAllBanners();
        Task<Banner> GetBannerById(string id);
        Task<Banner> GetBannerByIdWhereToQueueToCheck(string id);
        Task<Banner> GetBannerByIdWhereCheckSuccessful(string id);
        Task<Banner> GetBannerByIdAnyStatus(string id);
        Task<Guid> AddBannerAndGetBannerId(string title, string subtitle, string description, string linkToBrowserPage, string photoUrl);
        Task AddBannerToQueueToCheck(string bannerId);
        Task SetStatusCheckSuccessful(string bannerId);
        Task SetStatusCheckNotSuccessful(string bannerId, string comment);
        Task SetStatusReleased(string bannerId);
        Task SetStatusReleasePlanned(string bannerId, DateTime releaseDate);
    }
}
