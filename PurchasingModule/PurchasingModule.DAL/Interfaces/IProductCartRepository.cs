using PurchasingModule.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchasingModule.DAL.Interfaces
{
    public interface IProductCartRepository : IRepository<ProductCart>
    {
        void CreateProductCart(ProductCart productCart);
        void EditProductCart(ProductCart productCart);
        ProductCart GetProductCartDetails(int productCartId);
        void DeleteProductCart(int productCartId);
        IEnumerable<ProductCart> GetProductCarts();
        IEnumerable<ProductCart> GetProductsForCart(int cartId);

    }
}
