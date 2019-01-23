using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseModule.DAL.Interfaces;
using WarehouseModule.DAL.Models;

namespace WarehouseModule.Server.Services.ProductInventory
{
    public class ProductInventoryService : IProductInventoryService
    {
        public IUnitOfWork unitOfWork = null;

        public ProductInventoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddProductInventory(DAL.Models.ProductInventory productInventory)
        {
            unitOfWork.productInventoryRepository.Create(productInventory);
            unitOfWork.Commit();
        }

        public void DeleteProductInventory(int productInventoryId)
        {
            var productInventory = unitOfWork.productInventoryRepository.Details(productInventoryId);
            if (productInventory == null)
            {
                throw new Exception($"No inventory found for invetoryId: {productInventoryId}");

            }
            unitOfWork.productRepository.Delete(productInventoryId);
            unitOfWork.Commit();
        }

        public IEnumerable<DAL.Models.ProductInventory> GetInventoriesForProduct(int productId)
        {
            var inventories = unitOfWork.productInventoryRepository.GetInventoriesForProduct(productId);
            return inventories.ToList();
        }

        public IEnumerable<DAL.Models.ProductInventory> GetAllProductInventories()
        {
            var inventories = unitOfWork.productInventoryRepository.GetAll().ToList();
            return inventories;
        }

        public DAL.Models.ProductInventory GetProductInventory(int productInventoryId)
        {
            var inventory = unitOfWork.productInventoryRepository.Details(productInventoryId);
            return inventory;
        }
         

        public void UpdateProductInventory(DAL.Models.ProductInventory productInventory)
        {
            unitOfWork.productInventoryRepository.Edit(productInventory);
            unitOfWork.Commit();
        }
    }
}
