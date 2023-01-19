using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using IdentityMicroservice.BLL.Interfaces;
using MassTransit;

namespace IdentityMicroservice.API.Consumers
{
    public class RegisterConsumer : IConsumer<RegisterRequest>
    {
        private readonly IIdentityService _identityService;

        public RegisterConsumer(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task Consume(ConsumeContext<RegisterRequest> context)
        {
            try
            {
                var result = await _identityService.Register(context.Message);
                await context.RespondAsync(result);
            }
            catch (Exception ex)
            {
                await context.RespondAsync(new LoginRegisterResponse { Token = "", ErrorMessage = ex.Message });
            }
        }
    }
}
