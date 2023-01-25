using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;

namespace AdvertisementsMicroservice.BLL.Interfaces
{
    public interface IAdvertisementsService
    {
        Task<GetAllBannersResponse> GetAllBanners();
        Task<GetAllBannersResponse> GetAllBannersByUserId(GetAllBannersByUserIdRequest getAllBannersByUserIdRequest);
        Task<AddBannerResponse> AddBanner(AddBannerRequest addBannerRequest);
        Task<DeleteBannerResponse> DeleteBanner(DeleteBannerRequest deleteBannerRequest);
    }
}
