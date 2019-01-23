using System;
using System.Collections.Generic;
using System.Text;

namespace PurchasingModule.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICartRepository CartRepository { get; }
        IProductCartRepository ProductCartRepository { get; }
        IOrderRepository OrderRepository { get; }

        void Commit();
    }
}
