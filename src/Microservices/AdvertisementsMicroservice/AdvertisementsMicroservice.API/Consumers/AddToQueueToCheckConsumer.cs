using AdvertisementsMicroservice.BLL.Interfaces;
using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using MassTransit;

namespace AdvertisementsMicroservice.API.Consumers
{
    public class AddToQueueToCheckConsumer : IConsumer<AddToQueueToCheckRequest>
    {
        private readonly IAdvertisementsService _advertisementsService;

        public AddToQueueToCheckConsumer(IAdvertisementsService advertisementsService)
        {
            _advertisementsService = advertisementsService;
        }

        public async Task Consume(ConsumeContext<AddToQueueToCheckRequest> context)
        {
            try
            {
                var result = await _advertisementsService.AddToQueueToCheck(context.Message);
                await context.RespondAsync(result);
            }
            catch (Exception ex)
            {
                await context.RespondAsync(new SetStatusResponse { Message = ex.Message });
            }
        }
    }
}
