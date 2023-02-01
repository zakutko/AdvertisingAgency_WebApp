using AdvertisementsMicroservice.BLL.Interfaces;
using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using MassTransit;

namespace AdvertisementsMicroservice.API.Consumers
{
    public class CheckPlannedReleaseConsumer : IConsumer<CheckPlannedReleaseRequest>
    {
        private readonly IAdvertisementsService _advertisementsService;

        public CheckPlannedReleaseConsumer(IAdvertisementsService advertisementsService)
        {
            _advertisementsService = advertisementsService;
        }

        public async Task Consume(ConsumeContext<CheckPlannedReleaseRequest> context)
        {
            try
            {
                var result = await _advertisementsService.CheckPlannedRelease(context.Message);
                await context.RespondAsync(result);
            }
            catch (Exception ex)
            {
                await context.RespondAsync(new MessageResponse { Message = ex.Message });
            }
        }
    }
}
