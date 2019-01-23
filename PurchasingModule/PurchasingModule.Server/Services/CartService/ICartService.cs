using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchasingModule.Server.Services.CartService
{
    public interface ICartService
    {
        void AddCart(DAL.Models.Cart cart);
        DAL.Models.Cart GetCartDetails(int cartId);
        void EditCart(DAL.Models.Cart cart);
        void DeleteCart(int cartId);
        IEnumerable<DAL.Models.Cart> GetCarts();
        DAL.Models.Cart GetPersonCart(int personId);

    }
}
