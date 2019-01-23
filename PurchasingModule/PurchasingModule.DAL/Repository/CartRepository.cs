using PurchasingModule.DAL.Interfaces;
using PurchasingModule.DAL.Models;
using PurchasingModule.DAL.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurchasingModule.DAL.Repository
{
    public class CartRepository : Repository<CartRepository>, ICartRepository
    {
        private PurchasingContext Context
        {
            get
            {
                return db as PurchasingContext;
            }
        }
        public CartRepository(PurchasingContext purchasingContext) : base(purchasingContext)
        {

        }
        public void CreateCart(Cart cart)
        {
            Context.Cart.Add(cart);
            Context.SaveChanges();
        }

        public void DeleteCart(int cartId)
        {
            var cart = Context.Cart.SingleOrDefault(c => c.Id == cartId);
            if(cart != null)
            {
                Context.Cart.Remove(cart);
                Context.SaveChanges();
            }
        }

        public void EditCart(Cart cart)
        {
            Context.Cart.Update(cart);
            Context.SaveChanges();
        }

        public Cart GetCartDetails(int cartId)
        {
            var cart = Context.Cart.SingleOrDefault(c => c.Id == cartId);
            return cart;
        }

        public IEnumerable<Cart> GetCarts()
        {
            var carts = Context.Cart.ToList();
            return carts;
        }

        public Cart GetPersonCart(int personId)
        {
            var personCart = Context.Cart.SingleOrDefault(c => c.PersonId == personId && c.OrderSent == false);
            return personCart;
        }
    }
}
