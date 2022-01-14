using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace InventoryTracker.Models
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options)
            : base(options) { }

        public DbSet<InventoryItem> InventoryItems { get; set; } = null!;
    }
}
