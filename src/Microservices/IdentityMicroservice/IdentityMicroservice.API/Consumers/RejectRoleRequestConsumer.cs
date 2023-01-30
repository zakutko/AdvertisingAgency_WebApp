using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using IdentityMicroservice.BLL.Interfaces;
using MassTransit;

namespace IdentityMicroservice.API.Consumers
{
    public class RejectRoleRequestConsumer : IConsumer<RejectRoleRequest>
    {
        private readonly IIdentityService _identityService;

        public RejectRoleRequestConsumer(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task Consume(ConsumeContext<RejectRoleRequest> context)
        {
            try
            {
                var result = await _identityService.RejectRoleRequest(context.Message);
                await context.RespondAsync(result);
            }
            catch (Exception ex)
            {
                await context.RespondAsync(new MessageResponse { Message = ex.Message });
            }
        }
    }
}
