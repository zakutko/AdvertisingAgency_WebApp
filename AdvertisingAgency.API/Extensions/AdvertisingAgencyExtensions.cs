using AdvertisingAgency.Contracts.Requests;
using MassTransit;

namespace AdvertisingAgency.API.Extensions
{
    public static class AdvertisingAgencyExtensions
    {
        public static IServiceCollection AddAdvertisingAgencyServices(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq();

                x.AddRequestClient<LoginRequest>();
                x.AddRequestClient<RegisterRequest>();
                x.AddRequestClient<GetCurrentUserRequest>();
                x.AddRequestClient<IsExistByEmailOrUsernameRequest>();
                x.AddRequestClient<UpdateRoleRequest>();
                x.AddRequestClient<GetAllUsersRequest>();
                x.AddRequestClient<GetAllRoleRequestsRequest>();
                x.AddRequestClient<DeleteUserRequest>();
                x.AddRequestClient<GetAllBannersRequest>();
                x.AddRequestClient<AddBannerRequest>();
                x.AddRequestClient<GetAllBannersByUserIdRequest>();
            });

            services.AddOptions<MassTransitHostOptions>()
                .Configure(options =>
                {
                    options.WaitUntilStarted = true;

                    options.StartTimeout = TimeSpan.FromSeconds(10);

                    options.StopTimeout = TimeSpan.FromSeconds(30);
                });

            return services;
        }
    }
}
