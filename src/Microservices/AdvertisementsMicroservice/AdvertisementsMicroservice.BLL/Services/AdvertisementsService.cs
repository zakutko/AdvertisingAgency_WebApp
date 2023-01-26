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
            await _userBannerRepository.DeleteUserBanner(deleteBannerRequest.UserId, deleteBannerRequest.BannerId);
            return new DeleteBannerResponse { Message = "Delete successful!" };
        }

        public async Task<SetStatusResponse> AddToQueueToCheck(AddToQueueToCheckRequest addToQueueToCheckRequest)
        {
            await _bannerRepository.AddBannerToQueueToCheck(addToQueueToCheckRequest.BannerId);
            return new SetStatusResponse { Message = "Successful added to queue to check" };
        }

        public async Task<GetAllBannersResponse> GetAllBannersWhereStatusInQueueToCheck()
        {
            var userBanners = await _userBannerRepository.GetAllUserBanners();

            var response = new GetAllBannersResponse();

            foreach (var item in userBanners)
            {
                var banner = await _bannerRepository.GetBannerByIdWhereToQueueToCheck(item.BannerId.ToString());
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

        public async Task<GetAllBannersResponse> GetAllBannersWhereStatusCheckSuccessful()
        {
            var userBanners = await _userBannerRepository.GetAllUserBanners();

            var response = new GetAllBannersResponse();

            foreach (var item in userBanners)
            {
                var banner = await _bannerRepository.GetBannerByIdWhereCheckSuccessful(item.BannerId.ToString());
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

        public async Task<SetStatusResponse> SetStatusCheckSuccessful(SetStatusCheckSuccessfulRequest setStatusCheckSuccessfulRequest)
        {
            await _bannerRepository.SetStatusCheckSuccessful(setStatusCheckSuccessfulRequest.BannerId);
            return new SetStatusResponse { Message = "Successful update status to Check Successful" };
        }

        public async Task<SetStatusResponse> SetStatusCheckNotSuccessful(SetStatusCheckNotSuccessfulRequest setStatusCheckSuccessfulRequest)
        {
            await _bannerRepository.SetStatusCheckNotSuccessful(setStatusCheckSuccessfulRequest.BannerId, setStatusCheckSuccessfulRequest.Comment);
            return new SetStatusResponse { Message = "Successful update status to Check Not Successful" };
        }

        public async Task<SetStatusResponse> SetStatusReleased(SetStatusReleasedRequest setStatusReleasedRequest)
        {
            await _bannerRepository.SetStatusReleased(setStatusReleasedRequest.BannerId);
            return new SetStatusResponse { Message = "Successful update status to Released" };
        }

        public async Task<SetStatusResponse> SetStatusReleasePlanned(SetStatusReleasePlannedRequest setStatusReleasePlannedRequest)
        {
            await _bannerRepository.SetStatusReleasePlanned(setStatusReleasePlannedRequest.BannerId, setStatusReleasePlannedRequest.ReleaseDate);
            return new SetStatusResponse { Message = "Successful update status to Released Planned" };
        }
    }
}