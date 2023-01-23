using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using IdentityMicroservice.BLL.Interfaces;
using MassTransit;

namespace IdentityMicroservice.API.Consumers
{
    public class GetAllRoleRequestConsumer : IConsumer<GetAllRoleRequestsRequest>
    {
        private readonly IIdentityService _identityService;

        public GetAllRoleRequestConsumer(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task Consume(ConsumeContext<GetAllRoleRequestsRequest> context)
        {
            try
            {
                var result = await _identityService.GetAllRoleRequests(context.Message);
                await context.RespondAsync(result);
            }
            catch
            {
                await context.RespondAsync(new List<GetAllRoleRequestResponse>());
            }
        }
    }
}
