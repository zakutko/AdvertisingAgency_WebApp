using AdvertisementsMicroservice.BLL.Interfaces;
using AdvertisementsMicroservice.DAL.Interfaces;
using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;

namespace AdvertisementsMicroservice.BLL.Services
{
    public class AdvertisementsService : IAdvertisementsService
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly IUserBannerRepository _userBannerRepository;

        public AdvertisementsService(IBannerRepository bannerRepository, IUserBannerRepository userBannerRepository)
        {
            _bannerRepository = bannerRepository;
            _userBannerRepository = userBannerRepository;
        }

        public async Task<GetAllBannersResponse> GetAllBanners(GetAllBannersRequest getAllBannersRequest)
        {
            var userBanners = await _userBannerRepository.GetAllUserBanners();

            var response = new GetAllBannersResponse();

            foreach (var item in userBanners)
            {
                response.BannerList.Add(new BannerResponse
                {
                    UserId = item.UserId,
                    Title = _bannerRepository.GetBannerTitleByBannerId(item.BannerId),
                    SubTitle = _bannerRepository.GetBannerSubTitleByBannerId(item.BannerId),
                    Description = _bannerRepository.GetBannerDescriptionByBannerId(item.BannerId),
                    LinkToBrowserPage = _bannerRepository.GetBannerLinkToBrowserPageByBannerId(item.BannerId),
                    ReleaseDate = _bannerRepository.GetBannerReleaseDateByBannerId(item.BannerId),
                    Status = _bannerRepository.GetBannerStatusByBannerId(item.BannerId)
                });
            }
        }
    }
}
