using Microsoft.AspNetCore.Mvc;
using InventoryTracker.Models;
using System.Net;
using System.Web.Http;

namespace InventoryTracker.Controllers
{
    public class InventoryItemsController : Controller
    {
        static readonly InventoryRepository repository = new InventoryRepository();
        public IActionResult Index()
        {
            return View();
        }
        public IEnumerable<InventoryItem> GetAllProducts()
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
