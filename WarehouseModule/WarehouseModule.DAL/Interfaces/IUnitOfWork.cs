using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseModule.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository productRepository { get; }
        IProductInventoryRepository productInventoryRepository { get; }
        void Commit();
    }
}
