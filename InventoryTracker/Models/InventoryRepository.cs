namespace InventoryTracker.Models
{
    public class InventoryRepository : IInventoryRepository
    {
        private InventoryContext _context;

        public InventoryRepository(InventoryContext context)
        {
            _context = context;
        }

        public IEnumerable<InventoryItem> GetAll()
        {
            return _context.InventoryItems.ToList();
        }

        public InventoryItem Get(int id)
        {
            return _context.InventoryItems.Find(id);
        }

        public InventoryItem Add(InventoryItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _context.InventoryItems.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            InventoryItem toRemove = _context.InventoryItems.Find(id);
            if (toRemove != null)
            {
                _context.InventoryItems.Remove(toRemove);
            }
        }

        public bool Update(InventoryItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _context.InventoryItems.Update(item);
            _context.SaveChanges();
            return true;
        }

    }
}
