using AdvertisementsMicroservice.DAL.Models;

namespace AdvertisementsMicroservice.DAL.Interfaces
{
    public interface IBannerRepository
    {
        Task<IEnumerable<Banner>> GetAllBanners();
        Task<Banner> GetBannerById(string id);
    }
}
