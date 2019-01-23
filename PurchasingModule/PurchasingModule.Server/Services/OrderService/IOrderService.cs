using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchasingModule.Server.Services.OrderService
{
    public interface IOrderService
    {
        void AddOrder(DAL.Models.Order order);
        void EditOrder(DAL.Models.Order order);
        DAL.Models.Order GetOrderDetails(int orderId);
        void DeleteOrder(int orderId);
        IEnumerable<DAL.Models.Order> GetOrders();
        IEnumerable<DAL.Models.Order> GetPersonOrders(int personId);
    }
}
