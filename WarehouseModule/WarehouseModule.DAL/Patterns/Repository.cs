using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseModule.DAL.Interfaces;

namespace WarehouseModule.DAL.Patterns
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext db;
        public Repository(DbContext dbContext)
        {
            db = dbContext;
        }
    }
}
