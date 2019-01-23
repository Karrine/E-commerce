using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseModule.DAL.Interfaces;
using WarehouseModule.DAL.Models;
using WarehouseModule.DAL.Repository;

namespace WarehouseModule.DAL.Patterns
{
    public class UnitOfWork : IUnitOfWork
    {
        private WarehouseContext dbContext { get; }

        public IProductRepository productRepository => new ProductRepository(dbContext);
        public IProductInventoryRepository productInventoryRepository => new ProductInventoryRepository(dbContext);

        public UnitOfWork(WarehouseContext warehouseContext)
        {
            dbContext = warehouseContext;

        }
        public UnitOfWork(DbContext context)
        {
            dbContext = context as WarehouseContext;

        }
        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
