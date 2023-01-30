using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using IdentityMicroservice.BLL.Interfaces;
using MassTransit;

namespace IdentityMicroservice.API.Consumers
{
    public class AcceptRoleRequestConsumer : IConsumer<AcceptRoleRequest>
    {
        private readonly IIdentityService _identityService;

        public AcceptRoleRequestConsumer(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task Consume(ConsumeContext<AcceptRoleRequest> context)
        {
            try
            {
                var result = await _identityService.AcceptRoleRequest(context.Message);
                await context.RespondAsync(result);
            }
            catch (Exception ex)
            {
                await context.RespondAsync(new MessageResponse { Message = ex.Message });
            }
        }
    }
}
