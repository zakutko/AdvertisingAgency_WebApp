using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingAgency.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IBus _bus;

        public IdentityController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginRegisterResponse>> Login(LoginRequest loginRequest)
        {
            try
            {
                var response = await _bus.Request<LoginRequest, LoginRegisterResponse>(loginRequest);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginRegisterResponse>> Register(RegisterRequest registerRequest)
        {
            try
            {
                var response = await _bus.Request<RegisterRequest, LoginRegisterResponse>(registerRequest);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("currentUser")]
        public async Task<ActionResult<GetCurrentUserResponse>> GetCurrentUser(string token)
        {
            try
            {
                var getCurrUserRequest = new GetCurrentUserRequest { Token = token };
                var response = await _bus.Request<GetCurrentUserRequest, GetCurrentUserResponse>(getCurrUserRequest);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("isExistByEmail")]
        public async Task<ActionResult<IsExistReponse>> IsExistByEmailOrUsername(string requestValue)
        {
            try
            {
                var request = new IsExistByEmailOrUsernameRequest { RequestValue = requestValue };
                var response = await _bus.Request<IsExistByEmailOrUsernameRequest, IsExistReponse>(request);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
