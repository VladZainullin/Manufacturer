using MassTransit;
using MessageBroker.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace MessageBroker;

public static class DependencyInjection
{
    public static IServiceCollection AddMessageBrokerServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMassTransit(busRegistrationConfigurator =>
        {
            busRegistrationConfigurator.AddEntityFrameworkOutbox<AppDbContext>(
                static entityFrameworkOutboxConfigurator =>
                {
                    entityFrameworkOutboxConfigurator.UsePostgres();
                    entityFrameworkOutboxConfigurator.UseBusOutbox();
                });

            busRegistrationConfigurator.UsingRabbitMq((context, configurator) =>
            {
                var options = configuration.GetRequiredSection("RabbitMQ").Get<RabbitMqOptions>()!;
                configurator.Host(
                    host: options.Host,
                    port: options.Port,
                    virtualHost: options.VirtualHost,
                    hostConfigurator =>
                    {
                        hostConfigurator.Username(options.Username);
                        hostConfigurator.Password(options.Password);
                    });

                configurator.AutoStart = options.AutoStart;

                configurator.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}