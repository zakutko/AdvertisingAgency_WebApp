using AdvertisementsMicroservice.DAL.Interfaces;
using AdvertisementsMicroservice.DAL.Repositories;
using MassTransit;

namespace AdvertisementsMicroservice.API.Extensions
{
    public static class AdvertisementsMicroserviceExtensions
    {
        public static IServiceCollection AddAdvertisementsServices(this IServiceCollection services)
        {
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IUserBannerRepository, UserBannerRepository>();  

            services.AddMassTransit(x =>
            {

                x.SetKebabCaseEndpointNameFormatter();
                x.AddDelayedMessageScheduler();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.UseMessageRetry(r =>
                    {
                        r.Incremental(3, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
                    });

                    cfg.UseDelayedMessageScheduler();
                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}