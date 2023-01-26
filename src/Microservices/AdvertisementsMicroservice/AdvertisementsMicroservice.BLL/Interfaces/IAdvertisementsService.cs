using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;

namespace AdvertisementsMicroservice.BLL.Interfaces
{
    public interface IAdvertisementsService
    {
        Task<GetAllBannersResponse> GetAllBanners();
        Task<GetAllBannersResponse> GetAllBannersByUserId(GetAllBannersByUserIdRequest getAllBannersByUserIdRequest);
        Task<GetAllBannersResponse> GetAllBannersWhereStatusInQueueToCheck();
        Task<GetAllBannersResponse> GetAllBannersWhereStatusCheckSuccessful();
        Task<AddBannerResponse> AddBanner(AddBannerRequest addBannerRequest);
        Task<DeleteBannerResponse> DeleteBanner(DeleteBannerRequest deleteBannerRequest);
        Task<SetStatusResponse> AddToQueueToCheck(AddToQueueToCheckRequest addToQueueToCheckRequest);
        Task<SetStatusResponse> SetStatusCheckSuccessful(SetStatusCheckSuccessfulRequest setStatusCheckSuccessfulRequest);
        Task<SetStatusResponse> SetStatusCheckNotSuccessful(SetStatusCheckNotSuccessfulRequest setStatusCheckSuccessfulRequest);
        Task<SetStatusResponse> SetStatusReleased(SetStatusReleasedRequest setStatusReleasedRequest);
        Task<SetStatusResponse> SetStatusReleasePlanned(SetStatusReleasePlannedRequest setStatusReleasePlannedRequest);
    }
}
