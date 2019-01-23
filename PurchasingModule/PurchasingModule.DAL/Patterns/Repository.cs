using Microsoft.EntityFrameworkCore;
using PurchasingModule.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchasingModule.DAL.Patterns
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
