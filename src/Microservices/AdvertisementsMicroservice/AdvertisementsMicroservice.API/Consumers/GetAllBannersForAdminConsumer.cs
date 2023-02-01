using AdvertisementsMicroservice.BLL.Interfaces;
using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using MassTransit;

namespace AdvertisementsMicroservice.API.Consumers
{
    public class GetAllBannersForAdminConsumer : IConsumer<GetAllBannersForAdminRequest>
    {
        private readonly IAdvertisementsService _advertisementsService;

        public GetAllBannersForAdminConsumer(IAdvertisementsService advertisementsService)
        {
            _advertisementsService = advertisementsService;
        }

        public async Task Consume(ConsumeContext<GetAllBannersForAdminRequest> context)
        {
            try
            {
                var result = await _advertisementsService.GetAllBannersForAdmin(context.Message);
                await context.RespondAsync(result);
            }
            catch
            {
                await context.RespondAsync(new GetAllBannersResponse());
            }
        }
    }
}
