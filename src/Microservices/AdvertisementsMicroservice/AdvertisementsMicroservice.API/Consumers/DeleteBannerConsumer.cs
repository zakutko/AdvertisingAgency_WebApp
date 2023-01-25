using AdvertisementsMicroservice.BLL.Interfaces;
using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using MassTransit;

namespace AdvertisementsMicroservice.API.Consumers
{
    public class DeleteBannerConsumer : IConsumer<DeleteBannerRequest>
    {
        private readonly IAdvertisementsService _advertisementsService;

        public DeleteBannerConsumer(IAdvertisementsService advertisementsService)
        {
            _advertisementsService = advertisementsService;
        }

        public async Task Consume(ConsumeContext<DeleteBannerRequest> context)
        {
            try
            {
                var result = await _advertisementsService.DeleteBanner(context.Message);
                await context.RespondAsync(result);
            }
            catch (Exception ex)
            {
                await context.RespondAsync(new DeleteBannerResponse { Message = ex.Message });
            }
        }
    }
}
