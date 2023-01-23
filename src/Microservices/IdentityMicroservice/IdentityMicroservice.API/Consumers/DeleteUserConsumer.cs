using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using IdentityMicroservice.BLL.Interfaces;
using MassTransit;

namespace IdentityMicroservice.API.Consumers
{
    public class DeleteUserConsumer : IConsumer<DeleteUserRequest>
    {
        private readonly IIdentityService _identityService;

        public DeleteUserConsumer(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task Consume(ConsumeContext<DeleteUserRequest> context)
        {
            try
            {
                var result = await _identityService.DeleteUser(context.Message);
                await context.RespondAsync(result);
            }
            catch (Exception ex)
            {
                await context.RespondAsync(new DeleteUserResponse { Message = ex.Message });
            }
        }
    }
}
