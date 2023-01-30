using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using IdentityMicroservice.BLL.Interfaces;
using MassTransit;

namespace IdentityMicroservice.API.Consumers
{
    public class GetUsernameConsumer : IConsumer<GetUsernameRequest>
    {
        private readonly IIdentityService _identityService;

        public GetUsernameConsumer(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task Consume(ConsumeContext<GetUsernameRequest> context)
        {
            try
            {
                var result = await _identityService.GetUsername(context.Message);
                await context.RespondAsync(result);
            }
            catch
            {
                await context.RespondAsync(new GetUsernameResponse { Username = " " });
            }
        }
    }
}
