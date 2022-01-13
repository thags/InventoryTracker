namespace InventoryTracker.Models
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<InventoryItem> InventoryItems = new List<InventoryItem>();
        private int _nextId = 1;

        public InventoryRepository()
        {
            Add(new InventoryItem { Manufacturer = "testMan", Model = "Alpha", Location = "Room 303", SerialNumber = "123" });
        }

        public IEnumerable<InventoryItem> GetAll()
        {
            return InventoryItems;
        }

        public InventoryItem Get(int id)
        {
            return InventoryItems.Find(p => p.Id == id);
        }

        public InventoryItem Add(InventoryItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            InventoryItems.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            InventoryItems.RemoveAll(p => p.Id == id);
        }

        public bool Update(InventoryItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = InventoryItems.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            InventoryItems.RemoveAt(index);
            InventoryItems.Add(item);
            return true;
        }

    }
}
