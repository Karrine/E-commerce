using PurchasingModule.DAL.Interfaces;
using PurchasingModule.DAL.Models;
using PurchasingModule.DAL.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurchasingModule.DAL.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private PurchasingContext Context
        {
            get
            {
                return db as PurchasingContext;
            }
        }
        public OrderRepository(PurchasingContext purchasingContext) : base(purchasingContext)
        {

        }
        public void CreateOrder(Order order)
        {
            Context.Order.Add(order);
            Context.SaveChanges();
        }

        public void DeleteOrder(int orderId)
        {
            Order order = Context.Order.SingleOrDefault(o => o.Id == orderId);
            if(order != null)
            {
                Context.Order.Remove(order);
                Context.SaveChanges();
            }
        }

        public void EditOrder(Order order)
        {
            Context.Order.Update(order);
            Context.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var list = Context.Order.ToList();
            return list;
        }

        public Order GetOrderDetails(int orderId)
        {
            var order = Context.Order.SingleOrDefault(o => o.Id == orderId);
            return order;
        }

        public IEnumerable<Order> GetPersonOrders(int personId)
        {
            var orders = Context.Order.Where(o => o.PersonId == personId).ToList();
            return orders;
        }
    }
}
