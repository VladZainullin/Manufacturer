namespace MessageBroker.Options;

public sealed class RabbitMqOptions
{
    public required string Host { get; init; }

    public required ushort Port { get; init; }

    public required string VirtualHost { get; init; }

    public required string Username { get; init; }

    public required string Password { get; init; }

    public required bool AutoStart { get; init; }
}