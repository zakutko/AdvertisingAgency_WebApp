using AdvertisementsMicroservice.BLL.Interfaces;
using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using MassTransit;

namespace AdvertisementsMicroservice.API.Consumers
{
    public class SetStatusCheckSuccessfulConsumer : IConsumer<SetStatusCheckSuccessfulRequest>
    {
        private readonly IAdvertisementsService _advertisementsService;

        public SetStatusCheckSuccessfulConsumer(IAdvertisementsService advertisementsService)
        {
            _advertisementsService = advertisementsService;
        }

        public async Task Consume(ConsumeContext<SetStatusCheckSuccessfulRequest> context)
        {
            try
            {
                var result = await _advertisementsService.SetStatusCheckSuccessful(context.Message);
                await context.RespondAsync(result);
            }
            catch (Exception ex)
            {
                await context.RespondAsync(new SetStatusResponse { Message = ex.Message });
            }
        }
    }
}
