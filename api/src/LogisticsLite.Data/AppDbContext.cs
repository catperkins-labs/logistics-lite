using LogisticsLite.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsLite.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Item> Items => Set<Item>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<InventoryTransaction> InventoryTransactions => Set<InventoryTransaction>();
    public DbSet<InventoryBalance> InventoryBalances => Set<InventoryBalance>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Item>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Sku).HasMaxLength(100).IsRequired();
            e.Property(x => x.Name).HasMaxLength(255).IsRequired();
            e.HasIndex(x => x.Sku).IsUnique();
        });

        modelBuilder.Entity<Location>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Code).HasMaxLength(50).IsRequired();
            e.Property(x => x.Name).HasMaxLength(255).IsRequired();
            e.HasIndex(x => x.Code).IsUnique();
        });

        modelBuilder.Entity<InventoryTransaction>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.TransactionType).HasMaxLength(20).IsRequired();
            e.HasOne(x => x.Item).WithMany().HasForeignKey(x => x.ItemId);
            e.HasOne(x => x.Location).WithMany().HasForeignKey(x => x.LocationId);
        });

        modelBuilder.Entity<InventoryBalance>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.Item).WithMany().HasForeignKey(x => x.ItemId);
            e.HasOne(x => x.Location).WithMany().HasForeignKey(x => x.LocationId);
            e.HasIndex(x => new { x.ItemId, x.LocationId }).IsUnique();
        });
    }
}
