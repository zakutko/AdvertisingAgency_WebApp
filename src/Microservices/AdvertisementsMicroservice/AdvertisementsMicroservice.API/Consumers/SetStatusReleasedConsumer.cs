﻿using AdvertisementsMicroservice.BLL.Interfaces;
using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using MassTransit;

namespace AdvertisementsMicroservice.API.Consumers
{
    public class SetStatusReleasedConsumer : IConsumer<SetStatusReleasedRequest>
    {
        private readonly IAdvertisementsService _advertisementsService;

        public SetStatusReleasedConsumer(IAdvertisementsService advertisementsService)
        {
            _advertisementsService = advertisementsService;
        }

        public async Task Consume(ConsumeContext<SetStatusReleasedRequest> context)
        {
            try
            {
                var result = await _advertisementsService.SetStatusReleased(context.Message);
                await context.RespondAsync(result);
            }
            catch (Exception ex)
            {
                await context.RespondAsync(new MessageResponse { Message = ex.Message });
            }
        }
    }
}
