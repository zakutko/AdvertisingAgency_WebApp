using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;

namespace AdvertisementsMicroservice.BLL.Interfaces
{
    public interface IAdvertisementsService
    {
        Task<GetAllBannersResponse> GetAllBannersForAdmin(GetAllBannersForAdminRequest getAllBannersForAdminRequest);
        Task<GetAllBannersResponse> GetAllBanners();
        Task<GetAllBannersResponse> GetAllBannersByUserId(GetAllBannersByUserIdRequest getAllBannersByUserIdRequest);
        Task<GetAllBannersResponse> GetAllBannersWhereStatusInQueueToCheck();
        Task<GetAllBannersResponse> GetAllBannersWhereStatusCheckSuccessful();
        Task<MessageResponse> AddBanner(AddBannerRequest addBannerRequest);
        Task<MessageResponse> DeleteBanner(DeleteBannerRequest deleteBannerRequest);
        Task<MessageResponse> AddToQueueToCheck(AddToQueueToCheckRequest addToQueueToCheckRequest);
        Task<MessageResponse> SetStatusCheckSuccessful(SetStatusCheckSuccessfulRequest setStatusCheckSuccessfulRequest);
        Task<MessageResponse> SetStatusCheckNotSuccessful(SetStatusCheckNotSuccessfulRequest setStatusCheckSuccessfulRequest);
        Task<MessageResponse> SetStatusReleased(SetStatusReleasedRequest setStatusReleasedRequest);
        Task<MessageResponse> SetStatusReleasePlanned(SetStatusReleasePlannedRequest setStatusReleasePlannedRequest);
        Task<MessageResponse> UpdateBanner(UpdateBannerRequest updateAdvertisementRequest);
        Task<MessageResponse> CheckPlannedRelease(CheckPlannedReleaseRequest checkPlannedReleaseRequest);
    }
}
