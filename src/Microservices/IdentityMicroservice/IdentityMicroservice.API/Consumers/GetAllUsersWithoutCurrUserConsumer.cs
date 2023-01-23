using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using IdentityMicroservice.BLL.Interfaces;
using MassTransit;

namespace IdentityMicroservice.API.Consumers
{
    public class GetAllUsersWithoutCurrUserConsumer : IConsumer<GetAllUsersRequest>
    {
        private readonly IIdentityService _identityService;

        public GetAllUsersWithoutCurrUserConsumer(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task Consume(ConsumeContext<GetAllUsersRequest> context)
        {
            try
            {
                var result = await _identityService.GetAllUsersWithoutCurrUser(context.Message);
                await context.RespondAsync(result);
            }
            catch
            {
                await context.RespondAsync(new GetAllUsersResponse { UsersList = null });
            }
        }
    }
}
