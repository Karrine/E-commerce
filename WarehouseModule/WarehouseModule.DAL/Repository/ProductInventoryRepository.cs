using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using WarehouseModule.DAL.Models;
using WarehouseModule.DAL.Interfaces;
using WarehouseModule.DAL.Patterns;

namespace WarehouseModule.DAL.Repository
{
    public class ProductInventoryRepository : Repository<ProductInventory>, IProductInventoryRepository
    {
        private WarehouseContext Context
        {
            get
            {
                return db as WarehouseContext;
            }
        }
        public ProductInventoryRepository(WarehouseContext context) :base(context)
        {

        }

        public void Create(ProductInventory entity)
        {
            Context.ProductInventory.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var productInventory = Context.ProductInventory.SingleOrDefault(p => p.Id == id);
            if (productInventory != null)
            {
                Context.ProductInventory.Remove(productInventory);
                Context.SaveChanges();
            }
        }

        public ProductInventory Details(int productInventoryId)
        {
            var productInventory = Context.ProductInventory.SingleOrDefault(p => p.Id == productInventoryId);
            return productInventory;
        }

        public void Edit(ProductInventory entity)
        {
            Context.ProductInventory.Update(entity);
            Context.SaveChanges();
        }

        public IEnumerable<ProductInventory> GetAll()
        {
            var productInventories = Context.ProductInventory.ToList();
            return productInventories;
        }

        public IEnumerable<ProductInventory> GetInventoriesForProduct(int productId)
        {
            var inventoriesForProduct = Context.ProductInventory.Where(p => p.ProductId == productId).ToList();
            return inventoriesForProduct;
        }
    }
}
