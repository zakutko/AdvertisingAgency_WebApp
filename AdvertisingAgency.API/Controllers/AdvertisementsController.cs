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

        [HttpPost("addBanner")]
        public async Task<ActionResult<AddBannerResponse>> AddBanner(AddBannerRequest addBannerRequest)
        {
            try
            {
                var response = await _bus.Request<AddBannerRequest, AddBannerResponse>(addBannerRequest);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}