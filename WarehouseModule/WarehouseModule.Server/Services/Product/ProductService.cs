using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseModule.DAL.Interfaces;
using WarehouseModule.DAL.Models;

namespace WarehouseModule.Server.Services.Product
{
    public class ProductService : IProductService
    {
        public IUnitOfWork unitOfWork = null;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void AddProduct(DAL.Models.Product product)
        {
            unitOfWork.productRepository.Create(product);
            unitOfWork.Commit();
        }

        public void DeleteProduct(int productId)
        {
            var product = unitOfWork.productRepository.Details(productId);
            if(product == null)
            {
                throw new Exception($"No product found for {productId}");

            }
            unitOfWork.productRepository.Delete(productId);
            unitOfWork.Commit();
                     
        }

        public DAL.Models.Product GetProductDetails(int productId)
        {
            
            var product = unitOfWork.productRepository.Details(productId);
            if(product == null)
            {
                throw new Exception($"Product not found for id {productId}");
            }
            return product;
        }

        public IEnumerable<DAL.Models.Product> GetProducts()
        {
            var products = unitOfWork.productRepository.GetAll();
            return products.ToList();
        }

        public void UpdateProductDetails(DAL.Models.Product product)
        {
            unitOfWork.productRepository.Edit(product);
            unitOfWork.Commit();
        }
    }
}
