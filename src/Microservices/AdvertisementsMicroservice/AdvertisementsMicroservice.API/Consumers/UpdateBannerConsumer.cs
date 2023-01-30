using AdvertisementsMicroservice.BLL.Interfaces;
using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using MassTransit;

namespace AdvertisementsMicroservice.API.Consumers
{
    public class UpdateBannerConsumer : IConsumer<UpdateBannerRequest>
    {
        private readonly IAdvertisementsService _advertisementsService;

        public UpdateBannerConsumer(IAdvertisementsService advertisementsService)
        {
            _advertisementsService = advertisementsService;
        }

        public async Task Consume(ConsumeContext<UpdateBannerRequest> context)
        {
            try
            {
                var result = await _advertisementsService.UpdateBanner(context.Message);
                await context.RespondAsync(result);
            }
            catch (Exception ex)
            {
                await context.RespondAsync(new MessageResponse { Message = ex.Message });
            }
        }
    }
}
