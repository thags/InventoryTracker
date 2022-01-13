using System.ComponentModel.DataAnnotations;

namespace InventoryTracker.Models
{
    public class InventoryItem
    {
        [Required]
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Location { get; set; }
    }
}
