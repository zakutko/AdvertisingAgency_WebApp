using AdvertisementsMicroservice.API.Consumers;
using AdvertisementsMicroservice.BLL.Interfaces;
using AdvertisementsMicroservice.BLL.Services;
using AdvertisementsMicroservice.DAL.Interfaces;
using AdvertisementsMicroservice.DAL.Repositories;
using MassTransit;

namespace AdvertisementsMicroservice.API.Extensions
{
    public static class AdvertisementsMicroserviceExtensions
    {
        public static IServiceCollection AddAdvertisementsServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IAdvertisementsService, AdvertisementsService>();
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IUserBannerRepository, UserBannerRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<GetAllBannersConsumer>();
                x.AddConsumer<AddBannerConsumer>();
                x.AddConsumer<GetAllBannersByUserIdConsumer>();
                x.AddConsumer<DeleteBannerConsumer>();

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