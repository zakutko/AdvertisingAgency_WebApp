using AdvertisementsMicroservice.BLL.Interfaces;
using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using MassTransit;

namespace AdvertisementsMicroservice.API.Consumers
{
    public class SetStatusReleasePlannedConsumer : IConsumer<SetStatusReleasePlannedRequest>
    {
        private readonly IAdvertisementsService _advertisementsService;

        public SetStatusReleasePlannedConsumer(IAdvertisementsService advertisementsService)
        {
            _advertisementsService = advertisementsService;
        }

        public async Task Consume(ConsumeContext<SetStatusReleasePlannedRequest> context)
        {
            try
            {
                var result = await _advertisementsService.SetStatusReleasePlanned(context.Message);
                await context.RespondAsync(result);
            }
            catch (Exception ex)
            {
                await context.RespondAsync(new MessageResponse { Message = ex.Message });
            }
        }
    }
}
