using Ambev.DeveloperEvaluation.Domain.Messaging;
using MassTransit;

namespace Ambev.DeveloperEvaluation.Messaging.Services;

/// <summary>
/// Queue Service implementation for messaging operations.
/// </summary>
public class QueueService(IBus bus) : IQueueService
{
    /// <summary>
    /// Publishes a message to the queue
    /// </summary>
    /// <param name="message">The message to publish</param>
    /// <param name="cancellationToken">Cancellation token</param>
    public async Task Publish(object message, CancellationToken cancellationToken = default)
        => await bus.Publish(message, cancellationToken);

    /// <summary>
    /// Sends a message to the queue
    /// </summary>
    /// <param name="message">The message to send</param>
    /// <param name="cancellationToken">Cancellation token</param>
    public async Task Send(object message, CancellationToken cancellationToken = default)
        => await bus.Send(message, cancellationToken);
}