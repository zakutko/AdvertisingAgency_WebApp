using AdvertisementsMicroservice.BLL.Interfaces;
using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using MassTransit;

namespace AdvertisementsMicroservice.API.Consumers
{
    public class AddBannerConsumer : IConsumer<AddBannerRequest>
    {
        private readonly IAdvertisementsService _advertisementsService;

        public AddBannerConsumer(IAdvertisementsService advertisementsService)
        {
            _advertisementsService = advertisementsService;
        }

        public async Task Consume(ConsumeContext<AddBannerRequest> context)
        {
            try
            {
                var result = await _advertisementsService.AddBanner(context.Message);
                await context.RespondAsync(result);
            }
            catch (Exception ex)
            {
                await context.RespondAsync(new AddBannerResponse { Message = ex.Message });
            }
        }
    }
}
