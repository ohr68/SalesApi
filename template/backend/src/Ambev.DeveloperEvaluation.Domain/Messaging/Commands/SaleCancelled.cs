namespace Ambev.DeveloperEvaluation.Domain.Messaging.Commands;

/// <summary>
/// Message model for SaleCancelled event
/// </summary>
public class SaleCancelled : Message
{
    /// <summary>
    ///  Gets the unique identifier of the sale.
    /// </summary>
    public Guid Id { get; private set; }
    
    /// <summary>
    /// Gets whether the sale was canceled or not.
    /// </summary>
    public bool Cancelled { get; set; }
}