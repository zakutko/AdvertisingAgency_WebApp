using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;

namespace AdvertisementsMicroservice.BLL.Interfaces
{
    public interface IAdvertisementsService
    {
        Task<GetAllBannersResponse> GetAllBanners();
        Task<AddBannerResponse> AddBanner(AddBannerRequest addBannerRequest);
    }
}
