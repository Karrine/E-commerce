using PurchasingModule.DAL.Interfaces;
using PurchasingModule.DAL.Models;
using PurchasingModule.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchasingModule.DAL.Patterns
{
    public class UnitOfWork : IUnitOfWork
    {
        private PurchasingContext dbContext { get; }

        public ICartRepository CartRepository => new CartRepository(dbContext);

        public IProductCartRepository ProductCartRepository => new ProductCartRepository(dbContext);

        public IOrderRepository OrderRepository => new OrderRepository(dbContext);
        
        public UnitOfWork(PurchasingContext context)
        {
            dbContext = context;
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
