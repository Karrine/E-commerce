using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PurchasingModule.DAL.Models;
using PurchasingModule.Server.Services.ProductCartService;

namespace PurchasingModule.Server.Controllers
{
    [Route("api/productcart")]
    public class ProductCartController : Controller
    {
        public IProductCartService productCartService = null;
        public ProductCartController(IProductCartService productCartService)
        {
            this.productCartService = productCartService;
        }

        [HttpGet]
        [Route("get/{productCartId}")]
        public IActionResult GetProductCartDetails([FromRoute] int productCartId)
        {
            return Ok(productCartService.GetProductCartDetails(productCartId));
        }

        [HttpGet]
        [Route("get/forcart/{cartId}")]
        public IActionResult GetProductCartsForCart([FromRoute] int cartId)
        {
            return Ok(productCartService.GetProductCartsForCart(cartId));
        }

        [Route("add")]
        public IActionResult AddProductCart([FromBody] ProductCart productCart)
        {
            productCartService.AddProductCart(productCart);
            return Ok("Item added.");
        }

        [Route("update")]
        public IActionResult UpdateProductCart([FromBody] ProductCart productCart)
        {
            productCartService.EditProductCart(productCart);
            return Ok("Updated.");
        }
    }
}