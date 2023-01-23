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
        public async Task<ActionResult<GetAllBannersResponse>> GetAllBanners(GetAllBannersRequest getAllBannersRequest)
        {
            try
            {
                var response = await _bus.Request<GetAllBannersRequest, GetAllBannersResponse>(getAllBannersRequest);
                return Ok(response.Message.BannerList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}