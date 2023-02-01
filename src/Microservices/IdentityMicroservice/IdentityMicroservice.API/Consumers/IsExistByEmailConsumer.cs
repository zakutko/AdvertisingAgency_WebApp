﻿using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using IdentityMicroservice.BLL.Interfaces;
using MassTransit;

namespace IdentityMicroservice.API.Consumers
{
    public class IsExistByEmailConsumer : IConsumer<IsExistByEmailOrUsernameRequest>
    {
        private readonly IIdentityService _identityService;

        public IsExistByEmailConsumer(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task Consume(ConsumeContext<IsExistByEmailOrUsernameRequest> context)
        {
            try
            {
                var result = await _identityService.IsUserExistByEmailOrUsername(context.Message);
                await context.RespondAsync(result);
            }
            catch (Exception ex)
            {
                await context.RespondAsync(new IsExistReponse { IsExist = null, ErrorMessage = ex.Message });
            }
        }
    }
}
