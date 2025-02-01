namespace Ambev.DeveloperEvaluation.Domain.Messaging.Commands;

/// <summary>
/// Message model for ItemCancelled event
/// </summary>
public class ItemCancelled : Message
{
    /// <summary>
    ///  Gets the unique identifier of the item.
    /// </summary>
    public Guid Id { get; private set; }
    
    /// <summary>
    /// Gets whether the item was canceled or not.
    /// </summary>
    public bool Cancelled { get; set; }
}