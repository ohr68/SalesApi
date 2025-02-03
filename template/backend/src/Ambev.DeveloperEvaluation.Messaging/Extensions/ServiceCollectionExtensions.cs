using Ambev.DeveloperEvaluation.Domain.Messaging;
using Ambev.DeveloperEvaluation.Messaging.Services;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.Messaging.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(busConfig =>
        {
            busConfig.UsingRabbitMq((context, config) =>
            {
                var host = configuration.GetValue<string>("MassTransit:Host") ?? 
                           throw new ArgumentNullException("MassTransit:Host");
                var user = configuration.GetValue<string>("MassTransit:User") ?? 
                           throw new ArgumentNullException("MassTransit:User");
                var password = configuration.GetValue<string>("MassTransit:Password") ?? 
                               throw new ArgumentNullException("MassTransit:Password");
                
                config.Host(host, "/", x =>
                {
                    x.Username(user);
                    x.Password(password);
                });

                config.ConfigureEndpoints(context);
            });
        });

        services.AddScoped<IQueueService, QueueService>();
        
        return services;
    }
}