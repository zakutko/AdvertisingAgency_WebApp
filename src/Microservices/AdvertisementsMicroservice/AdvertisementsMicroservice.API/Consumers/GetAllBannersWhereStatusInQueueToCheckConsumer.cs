using AdvertisementsMicroservice.BLL.Interfaces;
using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using MassTransit;

namespace AdvertisementsMicroservice.API.Consumers
{
    public class GetAllBannersWhereStatusInQueueToCheckConsumer : IConsumer<GetAllBannersWhereStatusInQueueToCheckRequest>
    {
        private readonly IAdvertisementsService _advertisementsService;

        public GetAllBannersWhereStatusInQueueToCheckConsumer(IAdvertisementsService advertisementsService)
        {
            _advertisementsService = advertisementsService;
        }

        public async Task Consume(ConsumeContext<GetAllBannersWhereStatusInQueueToCheckRequest> context)
        {
            try
            {
                var result = await _advertisementsService.GetAllBannersWhereStatusInQueueToCheck();
                await context.RespondAsync(result);
            }
            catch
            {
                await context.RespondAsync(new GetAllBannersResponse());
            }
        }
    }
}
