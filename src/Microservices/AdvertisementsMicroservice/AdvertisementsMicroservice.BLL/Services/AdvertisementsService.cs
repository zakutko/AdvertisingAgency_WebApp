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
        private readonly IStatusRepository _statusRepository;

        public AdvertisementsService(IBannerRepository bannerRepository, IUserBannerRepository userBannerRepository, IStatusRepository statusRepository)
        {
            _bannerRepository = bannerRepository;
            _userBannerRepository = userBannerRepository;
            _statusRepository = statusRepository;
        }

        public async Task<AddBannerResponse> AddBanner(AddBannerRequest addBannerRequest)
        {
            var bannerId = await _bannerRepository.AddBannerAndGetBannerId(
                addBannerRequest.Title, 
                addBannerRequest.SubTitle, 
                addBannerRequest.Description, 
                addBannerRequest.LinkToBrowserPage,
                addBannerRequest.ImageUrl);

            await _userBannerRepository.AddUserBanner(addBannerRequest.UserId, bannerId);

            return new AddBannerResponse { Message = "Banner was added successful" };
        }

        public async Task<GetAllBannersResponse> GetAllBannersByUserId(GetAllBannersByUserIdRequest getAllBannersByUserIdRequest)
        {
            var userId = Guid.Parse(getAllBannersByUserIdRequest.UserId);
            var userBanners = await _userBannerRepository.GetAllUserBannersByUserId(userId);

            var response = new GetAllBannersResponse();

            foreach (var item in userBanners)
            {
                var banner = await _bannerRepository.GetBannerByIdAnyStatus(item.BannerId.ToString());
                if (banner != null)
                {
                    response.BannerList.Add(new BannerResponse
                    {
                        UserId = item.UserId.ToString(),
                        BannerId = item.BannerId.ToString(),
                        Title = banner.Title,
                        SubTitle = banner.SubTitle,
                        Description = banner.Description,
                        LinkToBrowserPage = banner.LinkToBrowserPage,
                        ReleaseDate = banner.ReleaseDate.ToShortDateString(),
                        Status = await _statusRepository.GetStatusNameById(banner.StatusId),
                        PhotoUrl = banner.PhotoUrl,
                        Comment = banner.Comment
                    });
                }
            }

            return response;
        }

        public async Task<GetAllBannersResponse> GetAllBanners()
        {
            var userBanners = await _userBannerRepository.GetAllUserBanners();

            var response = new GetAllBannersResponse();

            foreach (var item in userBanners)
            {
                var banner = await _bannerRepository.GetBannerById(item.BannerId.ToString());
                if (banner != null)
                {
                    response.BannerList.Add(new BannerResponse
                    {
                        UserId = item.UserId.ToString(),
                        BannerId = item.BannerId.ToString(),
                        Title = banner.Title,
                        SubTitle = banner.SubTitle,
                        Description = banner.Description,
                        LinkToBrowserPage = banner.LinkToBrowserPage,
                        ReleaseDate = banner.ReleaseDate.ToShortDateString(),
                        Status = await _statusRepository.GetStatusNameById(banner.StatusId),
                        PhotoUrl = banner.PhotoUrl,
                        Comment = banner.Comment
                    });
                }
            }

            return response;
        }

        public async Task<DeleteBannerResponse> DeleteBanner(DeleteBannerRequest deleteBannerRequest)
        {
            //TODO:
            return new DeleteBannerResponse { Message = "Delete successful!" };
        }
    }
}