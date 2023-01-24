using AdvertisementsMicroservice.BLL.Interfaces;
using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using MassTransit;

namespace AdvertisementsMicroservice.API.Consumers
{
    public class GetAllBannersConsumer : IConsumer<GetAllBannersRequest>
    {
        private readonly IAdvertisementsService _advertisementsService;

        public GetAllBannersConsumer(IAdvertisementsService advertisementsService)
        {
            _advertisementsService = advertisementsService;
        }

        public async Task Consume(ConsumeContext<GetAllBannersRequest> context)
        {
            try
            {
                var result = await _advertisementsService.GetAllBanners();
                await context.RespondAsync(result);
            }
            catch
            {
                await context.RespondAsync(new GetAllBannersResponse());
            }
        }
    }
}
