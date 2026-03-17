namespace LogisticsLite.Data.Entities;

public class InventoryTransaction
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; } = null!;
    public int LocationId { get; set; }
    public Location Location { get; set; } = null!;
    public int Quantity { get; set; }
    public string TransactionType { get; set; } = string.Empty; // e.g. "IN", "OUT", "ADJUST"
    public DateTime OccurredAt { get; set; } = DateTime.UtcNow;
}
