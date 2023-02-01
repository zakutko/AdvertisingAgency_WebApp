using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingAgency.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdvertisementsController : ControllerBase
    {
        private readonly IBus _bus;

        public AdvertisementsController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet("getAllBannersForAdmin")]
        public async Task<ActionResult<GetAllBannersResponse>> GetAllBannersForAdmin()
        {
            try
            {
                var getAllBannersForAdminRequest = new GetAllBannersForAdminRequest { Message = "Get all banners for admin" };
                var response = await _bus.Request<GetAllBannersForAdminRequest, GetAllBannersResponse>(getAllBannersForAdminRequest);
                return Ok(response.Message.BannerList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAllBanners")]
        public async Task<ActionResult<GetAllBannersResponse>> GetAllBanners(string message)
        {
            try
            {
                var getAllBannersRequest = new GetAllBannersRequest { Message = message };
                var response = await _bus.Request<GetAllBannersRequest, GetAllBannersResponse>(getAllBannersRequest);
                return Ok(response.Message.BannerList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAllBannersByUserId")]
        public async Task<ActionResult<GetAllBannersByUserIdRequest>> GetAllBannersByUserId(string userId)
        {
            try
            {
                var getAllBannersByUserIdRequest = new GetAllBannersByUserIdRequest { UserId = userId };
                var response = await _bus.Request<GetAllBannersByUserIdRequest, GetAllBannersResponse>(getAllBannersByUserIdRequest);
                return Ok(response.Message.BannerList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAllBannersWhereStatusInQueueToCheck")]
        public async Task<ActionResult<GetAllBannersResponse>> GetAllBannersWhereStatusInQueueToCheck()
        {
            try
            {
                var getAllBannersWhereStatusInQueueToCheckRequest = new GetAllBannersWhereStatusInQueueToCheckRequest { Message = "Get All banners where status - In queue to check" };
                var response = await _bus.Request<GetAllBannersWhereStatusInQueueToCheckRequest, GetAllBannersResponse>(getAllBannersWhereStatusInQueueToCheckRequest);
                return Ok(response.Message.BannerList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAllBannersWhereStatusCheckSuccessful")]
        public async Task<ActionResult<GetAllBannersResponse>> GetAllBannersWhereStatusCheckSuccessful()
        {
            try
            {
                var getAllBannersWhereStatusCheckSuccessfulRequest = new GetAllBannersWhereStatusCheckSuccessfulRequest { };
                var response = await _bus.Request<GetAllBannersWhereStatusCheckSuccessfulRequest, GetAllBannersResponse>(getAllBannersWhereStatusCheckSuccessfulRequest);
                return Ok(response.Message.BannerList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addBanner")]
        public async Task<ActionResult<MessageResponse>> AddBanner(AddBannerRequest addBannerRequest)
        {
            try
            {
                var response = await _bus.Request<AddBannerRequest, MessageResponse>(addBannerRequest);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteBanner")]
        public async Task<ActionResult<MessageResponse>> DeleteBanner(string userId, string bannerId)
        {
            try
            {
                var deleteBannerRequest = new DeleteBannerRequest { UserId = userId, BannerId = bannerId };
                var response = await _bus.Request<DeleteBannerRequest, MessageResponse>(deleteBannerRequest);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("addToQueueToCheck")]
        public async Task<ActionResult<MessageResponse>> AddToQueueToCheck(AddToQueueToCheckRequest addToQueueToCheckRequest)
        {
            try
            {
                var response = await _bus.Request<AddToQueueToCheckRequest, MessageResponse>(addToQueueToCheckRequest);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("setStatusCheckSuccessfull")]
        public async Task<ActionResult<MessageResponse>> SetStatusCheckSuccessful(SetStatusCheckSuccessfulRequest setStatusCheckSuccessfulRequest)
        {
            try
            {
                var response = await _bus.Request<SetStatusCheckSuccessfulRequest, MessageResponse>(setStatusCheckSuccessfulRequest);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("setStatusCheckNotSuccessful")]
        public async Task<ActionResult<MessageResponse>> SetStatusCheckNotSuccessful(SetStatusCheckNotSuccessfulRequest setStatusCheckNotSuccessfulRequest)
        {
            try
            {
                var response = await _bus.Request<SetStatusCheckNotSuccessfulRequest, MessageResponse>(setStatusCheckNotSuccessfulRequest);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("setStatusReleased")]
        public async Task<ActionResult<MessageResponse>> SetStatusReleased(SetStatusReleasedRequest setStatusReleasedRequest)
        {
            try
            {
                var response = await _bus.Request<SetStatusReleasedRequest, MessageResponse>(setStatusReleasedRequest);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("setStatusReleasePlanned")]
        public async Task<ActionResult<MessageResponse>> SetStatusReleasePlanned(SetStatusReleasePlannedRequest setStatusReleasePlannedRequest)
        {
            try
            {
                var response = await _bus.Request<SetStatusReleasePlannedRequest, MessageResponse>(setStatusReleasePlannedRequest);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updateBanner")]
        public async Task<ActionResult<MessageResponse>> UpdateBanner(UpdateBannerRequest updateAdvertisementRequest)
        {
            try
            {
                var response = await _bus.Request<UpdateBannerRequest, MessageResponse>(updateAdvertisementRequest);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("checkPlannedRelease")]
        public async Task<ActionResult<MessageResponse>> CheckPlannedRelease(CheckPlannedReleaseRequest checkPlannedReleaseRequest)
        {
            try
            {
                var response = await _bus.Request<CheckPlannedReleaseRequest, MessageResponse>(checkPlannedReleaseRequest);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}