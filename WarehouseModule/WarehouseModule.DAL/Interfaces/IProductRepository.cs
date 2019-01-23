using System;
using System.Collections.Generic;
using System.Text;
using WarehouseModule.DAL.Models;

namespace WarehouseModule.DAL.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        void Create(Product entity);
        Product Details(int productId);
        void Delete(int id);
        void Edit(Product entity);
        IEnumerable<Product> GetAll();
    }
}
