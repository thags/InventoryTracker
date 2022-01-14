namespace InventoryTracker.Models
{
    public class InventoryRepository : IInventoryRepository
    {
        private InventoryContext context;

        public InventoryRepository(InventoryContext context)
        {
            this.context = context;
        }

        public IEnumerable<InventoryItem> GetAll()
        {
            return context.InventoryItems.ToList();
        }

        public InventoryItem Get(int id)
        {
            return context.InventoryItems.Find(id);
        }

        public InventoryItem Add(InventoryItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            context.InventoryItems.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            InventoryItem toRemove = context.InventoryItems.Find(id);
            if (toRemove != null)
            {
                context.InventoryItems.Remove(toRemove);
            }
        }

        public bool Update(InventoryItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            context.InventoryItems.Update(item);
            context.SaveChanges();
            return true;
        }

    }
}
