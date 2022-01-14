using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InventoryTracker.Models;
using System.Web.Http;
using System.Net;

namespace InventoryTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemsController : ControllerBase
    {
        static readonly InventoryRepository repository = new InventoryRepository();

        public IEnumerable<InventoryItem> GetAll()
        {
            return repository.GetAll();
        }
        public InventoryItem GetProduct(int id)
        {
            InventoryItem item = repository.Get(id);
            return item;
        }
        public InventoryItem PostItem(InventoryItem item)
        {
            item = repository.Add(item);
            return item;
        }
        public void PutItem(int id, InventoryItem product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public void DeleteProduct(int id)
        {
            InventoryItem item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(id);
        }
    }
}
