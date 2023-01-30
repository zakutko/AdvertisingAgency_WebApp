using AdvertisementsMicroservice.BLL.Interfaces;
using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using MassTransit;

namespace AdvertisementsMicroservice.API.Consumers
{
    public class SetStatusCheckNotSuccessfulConsumer : IConsumer<SetStatusCheckNotSuccessfulRequest>
    {
        private readonly IAdvertisementsService _advertisementsService;

        public SetStatusCheckNotSuccessfulConsumer(IAdvertisementsService advertisementsService)
        {
            _advertisementsService = advertisementsService;
        }

        public async Task Consume(ConsumeContext<SetStatusCheckNotSuccessfulRequest> context)
        {
            try
            {
                var result = await _advertisementsService.SetStatusCheckNotSuccessful(context.Message);
                await context.RespondAsync(result);
            }
            catch (Exception ex)
            {
                await context.RespondAsync(new MessageResponse { Message = ex.Message });
            }
        }
    }
}
