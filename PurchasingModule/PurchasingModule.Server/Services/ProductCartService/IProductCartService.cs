using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchasingModule.Server.Services.ProductCartService
{
    public interface IProductCartService
    {
        void AddProductCart(DAL.Models.ProductCart productCart);
        void EditProductCart(DAL.Models.ProductCart productCart);
        void DeleteProductCart(int productCartId);
        DAL.Models.ProductCart GetProductCartDetails(int productCartId);
        IEnumerable<DAL.Models.ProductCart> GetProductCarts();
        IEnumerable<DAL.Models.ProductCart> GetProductCartsForCart(int cartId);


    }
}
