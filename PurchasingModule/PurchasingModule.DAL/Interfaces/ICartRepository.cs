using PurchasingModule.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchasingModule.DAL.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        void CreateCart(Cart cart);
        void EditCart(Cart cart);
        Cart GetCartDetails(int cartId);
        void DeleteCart(int cartId);
        IEnumerable<Cart> GetCarts();
        Cart GetPersonCart(int personId);
    }
}
