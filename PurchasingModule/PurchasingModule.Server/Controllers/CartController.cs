using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PurchasingModule.DAL.Models;
using PurchasingModule.Server.Services.CartService;

namespace PurchasingModule.Server.Controllers
{
    [Route("api/cart")]
    public class CartController : Controller
    {
        public ICartService cartService = null;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("get/{cartId}")]
        public IActionResult GetCartDetails(int cartId)
        {
            var cart = cartService.GetCartDetails(cartId);
            return Ok(cart);
        }

        [Route("add")]
        public IActionResult AddCart([FromBody] Cart cart)
        {
            cartService.AddCart(cart);
            return Ok("Cart added");
        }

        [Route("update")]
        public IActionResult UpdateCart([FromBody] Cart cart)
        {
            cartService.EditCart(cart);
            return Ok("Cart updated");
        }
        [Route("all")] 
        public IActionResult GetAllCarts()
        {
            return Ok(cartService.GetCarts());
        }
        [Route("personcart/{personId}")]
        public IActionResult GetPersonCart([FromRoute] int personId)
        {
            var cart = cartService.GetPersonCart(personId);
            return Ok(cart);
        }

    }
}