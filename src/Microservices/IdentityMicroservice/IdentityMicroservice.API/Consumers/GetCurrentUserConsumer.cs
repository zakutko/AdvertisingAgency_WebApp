using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using IdentityMicroservice.BLL.Interfaces;
using MassTransit;

namespace IdentityMicroservice.API.Consumers
{
    public class GetCurrentUserConsumer : IConsumer<GetCurrentUserRequest>
    {
        private readonly IIdentityService _identityService;

        public GetCurrentUserConsumer(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task Consume(ConsumeContext<GetCurrentUserRequest> context)
        {
            try
            {
                var result = await _identityService.GetCurrentUser(context.Message);
                await context.RespondAsync(result);
            }
            catch (Exception ex)
            {
                await context.RespondAsync(new GetCurrentUserResponse { ErrorMessage = ex.Message });
            }
        }
    }
}
