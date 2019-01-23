using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarehouseModule.Server.Services.ProductInventory;

namespace WarehouseModule.Server.Controllers
{
    [Route("api/inventory")]
    public class ProductInventoryController : Controller
    {
        public IProductInventoryService productInventoryService = null;
        public ProductInventoryController(IProductInventoryService productInventoryService)
        {
            this.productInventoryService = productInventoryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("productinventory/{productId}")]
        public IActionResult GetInventoriesForProduct(int productId)
        {
            var productInventories = productInventoryService.GetInventoriesForProduct(productId);
            return Ok(productInventories);
        }
        
        [Route("delete/{inventoryId}")]
        public IActionResult DeleteInventory([FromRoute] int inventoryId)
        {
            try
            {
                productInventoryService.DeleteProductInventory(inventoryId);
                return Ok(inventoryId);
            }
            catch (Exception e)
            {
                return NotFound(e.Message.ToString());
            }
        }
    }
}