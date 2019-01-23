using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseModule.Server.Services.ProductInventory
{
    public interface IProductInventoryService
    {
        DAL.Models.ProductInventory GetProductInventory(int productInventoryId);
        void AddProductInventory(DAL.Models.ProductInventory productInventory);
        void UpdateProductInventory(DAL.Models.ProductInventory productInventory);
        IEnumerable<DAL.Models.ProductInventory> GetAllProductInventories();
        void DeleteProductInventory(int productInventoryId);
        IEnumerable<DAL.Models.ProductInventory> GetInventoriesForProduct(int productId);

    }
}
