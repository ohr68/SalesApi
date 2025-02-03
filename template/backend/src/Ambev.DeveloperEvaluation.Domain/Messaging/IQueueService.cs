namespace Ambev.DeveloperEvaluation.Domain.Messaging;

/// <summary>
/// Queue Service interface for messaging operations.
/// </summary>
public interface IQueueService
{
    /// <summary>
    /// Publishes a message to the queue
    /// </summary>
    /// <param name="message">The message to publish</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task Publish(object message, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Sends a message to the queue
    /// </summary>
    /// <param name="message">The message to send</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task Send(object message,  CancellationToken cancellationToken = default);
}