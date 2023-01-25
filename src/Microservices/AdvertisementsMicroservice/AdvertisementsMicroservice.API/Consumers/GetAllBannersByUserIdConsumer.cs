using AdvertisementsMicroservice.BLL.Interfaces;
using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using MassTransit;

namespace AdvertisementsMicroservice.API.Consumers
{
    public class GetAllBannersByUserIdConsumer : IConsumer<GetAllBannersByUserIdRequest>
    {
        private readonly IAdvertisementsService _advertisementsService;

        public GetAllBannersByUserIdConsumer(IAdvertisementsService advertisementsService)
        {
            _advertisementsService = advertisementsService;
        }

        public async Task Consume(ConsumeContext<GetAllBannersByUserIdRequest> context)
        {
            try
            {
                var result = await _advertisementsService.GetAllBannersByUserId(context.Message);
                await context.RespondAsync(result);
            }
            catch
            {
                await context.RespondAsync(new GetAllBannersResponse());
            }
        }
    }
}
