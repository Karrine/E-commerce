using PurchasingModule.DAL.Interfaces;
using PurchasingModule.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchasingModule.Server.Services.ProductCartService
{
    public class ProductCartService : IProductCartService
    { 
        public IUnitOfWork unitOfWork = null;
        public ProductCartService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddProductCart(ProductCart productCart)
        {
            unitOfWork.ProductCartRepository.CreateProductCart(productCart);
            unitOfWork.Commit();
        }

        public void DeleteProductCart(int productCartId)
        {
            var productCart = unitOfWork.ProductCartRepository.GetProductCartDetails(productCartId);
            if (productCart == null)
            {
                throw new Exception($"No productCart found for {productCartId}");

            }
            unitOfWork.ProductCartRepository.DeleteProductCart(productCartId);
            unitOfWork.Commit();
        }

        public void EditProductCart(ProductCart productCart)
        {
            unitOfWork.ProductCartRepository.EditProductCart(productCart);
            unitOfWork.Commit();
        }

        public ProductCart GetProductCartDetails(int productCartId)
        {
            var details = unitOfWork.ProductCartRepository.GetProductCartDetails(productCartId);
            return details;
        }

        public IEnumerable<ProductCart> GetProductCarts()
        {
            return unitOfWork.ProductCartRepository.GetProductCarts();
        }

        public IEnumerable<ProductCart> GetProductCartsForCart(int cartId)
        {
            var list = unitOfWork.ProductCartRepository.GetProductsForCart(cartId);
            return list;
        }
    }
}
