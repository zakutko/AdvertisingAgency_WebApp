using IdentityMicroservice.API.Consumers;
using IdentityMicroservice.BLL.Helpers;
using IdentityMicroservice.BLL.Interfaces;
using IdentityMicroservice.BLL.Services;
using IdentityMicroservice.DAL.Interfaces;
using IdentityMicroservice.DAL.Repositories;
using MassTransit;

namespace IdentityMicroservice.API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IIdentityServiceHelper, IdentityServiceHelper>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<LoginConsumer>();
                x.AddConsumer<RegisterConsumer>();
                x.AddConsumer<GetCurrentUserConsumer>();

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
