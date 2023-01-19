using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using IdentityMicroservice.BLL.Interfaces;
using MassTransit;

namespace IdentityMicroservice.API.Consumers
{
    public class LoginConsumer : IConsumer<LoginRequest>
    {
        private readonly IIdentityService _identityService;

        public LoginConsumer(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task Consume(ConsumeContext<LoginRequest> context)
        {
            try
            {
                var result = await _identityService.Login(context.Message);
                await context.RespondAsync(result);
            }
            catch (Exception ex)
            {
                await context.RespondAsync(new LoginRegisterResponse { Token = "", ErrorMessage = ex.Message });
            }
        }
    }
}
