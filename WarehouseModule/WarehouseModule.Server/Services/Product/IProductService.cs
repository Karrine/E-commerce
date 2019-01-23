using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseModule.DAL.Models;

namespace WarehouseModule.Server.Services.Product
{
    public interface IProductService
    {
        DAL.Models.Product GetProductDetails(int productId);
        void AddProduct(DAL.Models.Product product);
        void UpdateProductDetails(DAL.Models.Product product);
        IEnumerable<DAL.Models.Product> GetProducts();
        void DeleteProduct(int productId);

    }
}
