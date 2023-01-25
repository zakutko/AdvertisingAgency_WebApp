using AdvertisementsMicroservice.DAL.Models;

namespace AdvertisementsMicroservice.DAL.Interfaces
{
    public interface IBannerRepository
    {
        Task<IEnumerable<Banner>> GetAllBanners();
        Task<Banner> GetBannerById(string id);
        Task<Banner> GetBannerByIdAnyStatus(string id);
        Task<Guid> AddBannerAndGetBannerId(string title, string subtitle, string description, string linkToBrowserPage, string photoUrl);
    }
}
