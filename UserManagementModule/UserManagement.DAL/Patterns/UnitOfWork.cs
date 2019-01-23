using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.DAL.Interfaces;
using UserManagement.DAL.Models;
using UserManagement.DAL.Repository;


namespace UserManagement.DAL.Patterns
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPersonRepository personRepository => new PersonRepository(dbContext);

        public IAddressRepository addressRepository => new AddressRepository(dbContext);

        private UserManagementContext dbContext { get; }

        public UnitOfWork(DbContext context)
        {
            dbContext = context as UserManagementContext;

        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
