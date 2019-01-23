using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.DAL.Interfaces;

namespace UserManagement.DAL.Patterns
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
