using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarehouseModule.Server.Services.Product;

namespace WarehouseModule.Server.Controllers
{
    [Route("api/products")]
    public class ProductController : Controller
    {
        private IProductService productService = null;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("get/{productId}")]
        public IActionResult GetProductDetails(int productId)
        {
            try
            {
                var productDetails = productService.GetProductDetails(productId);
                return Ok(productDetails);
            }
            catch (Exception e)
            {
                return NotFound(e.Message.ToString());
            }
        }
        [HttpGet]
        [Route("get/all")]
        public IActionResult GetAllProducts()
        {
            var products = productService.GetProducts();
            return Ok(products);
        }
        [Route("delete/{productId}")]
        public IActionResult DeleteProduct([FromRoute] int productId)
        {
            try
            {
                productService.DeleteProduct(productId);
                return Ok(productId);
            }
            catch(Exception e)
            {
                return NotFound(e.Message.ToString());
            }
        }
    }
}