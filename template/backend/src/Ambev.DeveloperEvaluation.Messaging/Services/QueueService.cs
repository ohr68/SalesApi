using Ambev.DeveloperEvaluation.Domain.Messaging;

namespace Ambev.DeveloperEvaluation.Messaging.Services;

/// <summary>
/// Queue Service implementation for messaging operations.
/// </summary>
public class QueueService : IQueueService
{
    /// <summary>
    /// Publishes a message to the queue
    /// </summary>
    /// <param name="message">The message to publish</param>
    /// <param name="cancellationToken">Cancellation token</param>
    public Task Publish(object message, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Sends a message to the queue
    /// </summary>
    /// <param name="message">The message to send</param>
    /// <param name="cancellationToken">Cancellation token</param>
    public Task Send(object message, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}