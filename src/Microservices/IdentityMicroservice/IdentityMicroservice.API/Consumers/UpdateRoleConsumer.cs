using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using IdentityMicroservice.BLL.Interfaces;
using MassTransit;

namespace IdentityMicroservice.API.Consumers
{
    public class UpdateRoleConsumer : IConsumer<UpdateRoleRequest>
    {
        private readonly IIdentityService _identityService;

        public UpdateRoleConsumer(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task Consume(ConsumeContext<UpdateRoleRequest> context)
        {
            var result = await _identityService.UpdateRoleByUserId(context.Message);
            await context.RespondAsync(result);
        }
    }
}
