namespace InventoryTracker.Models
{
    public interface IInventoryRepository
    {
        IEnumerable<InventoryItem> GetAll();
        InventoryItem Get(int id);
        InventoryItem Add(InventoryItem item);
        void Remove(int id);
        bool Update(InventoryItem item);
    }
}
