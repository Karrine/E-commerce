using System;
using System.Collections.Generic;
using System.Text;
using WarehouseModule.DAL.Models;

namespace WarehouseModule.DAL.Interfaces
{
    public interface IProductInventoryRepository : IRepository<ProductInventory>
    {
        void Create(ProductInventory entity);
        ProductInventory Details(int productInventoryId);
        void Delete(int id);
        void Edit(ProductInventory entity);
        IEnumerable<ProductInventory> GetAll();
        IEnumerable<ProductInventory> GetInventoriesForProduct(int productId); 
    }
}
