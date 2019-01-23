using PurchasingModule.DAL.Interfaces;
using PurchasingModule.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchasingModule.Server.Services.OrderService
{
    public class OrderService : IOrderService
    { 
        public IUnitOfWork unitOfWork = null;
        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddOrder(Order order)
        {
            unitOfWork.OrderRepository.CreateOrder(order);
            unitOfWork.Commit();
        }

        public void DeleteOrder(int orderId)
        {
            var order = unitOfWork.OrderRepository.GetOrderDetails(orderId);
            if (order == null)
            {
                throw new Exception($"No product found for {orderId}");

            }
            unitOfWork.OrderRepository.DeleteOrder(orderId);
            unitOfWork.Commit();

        }

        public void EditOrder(Order order)
        {
            unitOfWork.OrderRepository.EditOrder(order);
            unitOfWork.Commit();
        }

        public Order GetOrderDetails(int orderId)
        {
            var order = unitOfWork.OrderRepository.GetOrderDetails(orderId);
            return order;
        }

        public IEnumerable<Order> GetOrders()
        {
            return unitOfWork.OrderRepository.GetAllOrders();
        }

        public IEnumerable<Order> GetPersonOrders(int personId)
        {
            var list = unitOfWork.OrderRepository.GetPersonOrders(personId);
            return list;
        }
    }
}
