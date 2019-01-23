using PurchasingModule.DAL.Interfaces;
using PurchasingModule.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchasingModule.Server.Services.CartService
{
    public class CartService : ICartService
    {
        public IUnitOfWork unitOfWork = null;
        public CartService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddCart(Cart cart)
        {
            unitOfWork.CartRepository.CreateCart(cart);
            unitOfWork.Commit();
        }

        public void DeleteCart(int cartId)
        {
            var cart = unitOfWork.CartRepository.GetCartDetails(cartId);
            if (cart == null)
            {
                throw new Exception($"No cart found for {cartId}");

            }
            unitOfWork.CartRepository.DeleteCart(cartId);
            unitOfWork.Commit();
        }

        public void EditCart(Cart cart)
        {
            unitOfWork.CartRepository.EditCart(cart);
            unitOfWork.Commit();
        }

        public Cart GetCartDetails(int cartId)
        {
            var cart = unitOfWork.CartRepository.GetCartDetails(cartId);
            return cart;
        }

        public IEnumerable<Cart> GetCarts()
        {
            return unitOfWork.CartRepository.GetCarts();
        }

        public Cart GetPersonCart(int personId)
        {
            var personCart = unitOfWork.CartRepository.GetPersonCart(personId);
            return personCart;
        }
    }
}
