using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PurchasingModule.DAL.Models;
using PurchasingModule.Server.Services.OrderService;

namespace PurchasingModule.Server.Controllers
{
    [Route("api/order")]
    public class OrderController : Controller
    {
        public IOrderService orderService = null;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
         
        [HttpGet]
        [Route("get/{orderId}")]
        public IActionResult GetOrderDetails([FromRoute] int orderId)
        {
            return Ok(orderService.GetOrderDetails(orderId));
        }

        [HttpGet]
        [Route("personorders/{personId}")]
        public IActionResult GetPersonOrders([FromRoute] int personId)
        {
            return Ok(orderService.GetPersonOrders(personId));
        }

        [Route("add")]
        public IActionResult AddOrder([FromBody] Order order)
        {
            orderService.AddOrder(order);
            return Ok("Order added!");
        }

    }
}