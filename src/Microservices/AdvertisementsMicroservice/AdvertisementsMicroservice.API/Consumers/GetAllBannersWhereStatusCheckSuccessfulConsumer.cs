using AdvertisementsMicroservice.BLL.Interfaces;
using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using MassTransit;

namespace AdvertisementsMicroservice.API.Consumers
{
    public class GetAllBannersWhereStatusCheckSuccessfulConsumer : IConsumer<GetAllBannersWhereStatusCheckSuccessfulRequest>
    {
        private readonly IAdvertisementsService _advertisementsService;

        public GetAllBannersWhereStatusCheckSuccessfulConsumer(IAdvertisementsService advertisementsService)
        {
            _advertisementsService = advertisementsService;
        }

        public async Task Consume(ConsumeContext<GetAllBannersWhereStatusCheckSuccessfulRequest> context)
        {
            try
            {
                var result = await _advertisementsService.GetAllBannersWhereStatusCheckSuccessful();
                await context.RespondAsync(result);
            }
            catch
            {
                await context.RespondAsync(new GetAllBannersResponse());
            }
        }
    }
}
