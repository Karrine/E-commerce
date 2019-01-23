using PurchasingModule.DAL.Interfaces;
using PurchasingModule.DAL.Models;
using PurchasingModule.DAL.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurchasingModule.DAL.Repository
{
    public class ProductCartRepository : Repository<ProductCart>, IProductCartRepository
    {
        private PurchasingContext Context
        {
            get
            {
                return db as PurchasingContext;
            }
        }
        public ProductCartRepository(PurchasingContext purchasingContext) : base(purchasingContext)
        {

        }

        public void CreateProductCart(ProductCart productCart)
        {
            Context.ProductCart.Add(productCart);
            Context.SaveChanges();
        }

        public void DeleteProductCart(int productCartId)
        {
            var productCart = Context.ProductCart.SingleOrDefault(p => p.Id == productCartId);
            if (productCart != null)
            {
                Context.ProductCart.Remove(productCart);
                Context.SaveChanges();
            }
        }

        public void EditProductCart(ProductCart productCart)
        {
            Context.ProductCart.Update(productCart);
            Context.SaveChanges();
        }

        public ProductCart GetProductCartDetails(int productCartId)
        {
            var productCart = Context.ProductCart.SingleOrDefault(p => p.Id == productCartId);
            return productCart;
        }

        public IEnumerable<ProductCart> GetProductCarts()
        {
            var list = Context.ProductCart.ToList();
            return list;
        }

        public IEnumerable<ProductCart> GetProductsForCart(int cartId)
        {
            var list = Context.ProductCart.Where(p => p.CartId == cartId).ToList();
            return list;
        }
    }
}
