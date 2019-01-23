using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarehouseModule.DAL.Interfaces;
using WarehouseModule.DAL.Models;
using WarehouseModule.DAL.Patterns;

namespace WarehouseModule.DAL.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private WarehouseContext Context
        {
            get
            {
                return db as WarehouseContext;
            }
        }
        public ProductRepository(WarehouseContext context) : base(context)
        {

        }

        public void Create(Product entity)
        {
            Context.Product.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = Context.Product.SingleOrDefault(p => p.Id == id);
            if (product != null)
            {
                Context.Product.Remove(product);
                Context.SaveChanges();
            }
        }

        public Product Details(int productId)
        {
            var product = Context.Product.SingleOrDefault(p => p.Id == productId);
            return product;
        }

        public void Edit(Product entity)
        {
            Context.Product.Update(entity);
            Context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            var products = Context.Product.ToList();
            return products;
        }
    }
}
