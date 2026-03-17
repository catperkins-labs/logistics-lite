namespace LogisticsLite.Data.Entities;

public class Location
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Zone { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
