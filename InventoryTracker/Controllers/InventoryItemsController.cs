#nullable disable
using Microsoft.AspNetCore.Mvc;
using InventoryTracker.Models;

namespace InventoryTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemsController : ControllerBase
    {

        private IInventoryRepository _repository;

        public InventoryItemsController(IInventoryRepository repository)
        {
            _repository = repository;
        }

        // GET: api/InventoryItems
        [HttpGet]
        public IEnumerable<InventoryItem> GetEspressoItems()
        {
            return _repository.GetAll();
        }

        // GET: api/InventoryItems/5
        [HttpGet("{id}")]
        public InventoryItem GetEspressoItem(int id)
        {
            return _repository.Get(id);
        }

        // PUT: api/InventoryItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspressoItem(InventoryItem inventoryItem)
        {
            _repository.Update(inventoryItem);

            return NoContent();
        }

        // POST: api/InventoryItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InventoryItem>> PostEspressoItem(InventoryItem inventoryItem)
        {
            _repository.Add(inventoryItem);

            return CreatedAtAction(nameof(GetEspressoItem), new { id = inventoryItem.Id }, inventoryItem);
        }

        // DELETE: api/InventoryItems/5
        [HttpDelete("{id}")]
        public void DeleteEspressoItem(int id)
        {
            _repository.Remove(id);
        }
    }
}
