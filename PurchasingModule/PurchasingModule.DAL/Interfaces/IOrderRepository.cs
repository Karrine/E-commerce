using PurchasingModule.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchasingModule.DAL.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        void CreateOrder(Order order);
        void EditOrder(Order order);
        void DeleteOrder(int orderId);
        Order GetOrderDetails(int orderId);
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetPersonOrders(int personId);

    }
}
