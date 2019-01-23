using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.DAL.Interfaces;
using UserManagement.DAL.Models;
using UserManagement.DAL.Patterns;

namespace UserManagement.DAL.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private UserManagementContext Context
        {
            get
            {
                return db as UserManagementContext;
            }
        }
        public AddressRepository(UserManagementContext context) : base(context)
        {

        }

        public void Create(Address address)
        {
            Context.Address.Add(address);
            Context.SaveChanges();
        }

        public void Edit(Address address)
        {
            Context.Address.Update(address);
            Context.SaveChanges();
        }

        public Address Details(int addressId)
        {
            var address = Context.Address.SingleOrDefault(a => a.Id == addressId);
            return address;
        }

        public void Delete(int addressId)
        {
            var address = Context.Address.SingleOrDefault(a => a.Id == addressId);
            if(address != null)
            {
                Context.Address.Remove(address);
                Context.SaveChanges();
            }
        }

        public IEnumerable<Address> GetAll()
        {
            var addresses = Context.Address.ToList();
            return addresses;
        }

        public IEnumerable<Address> GetAddressesForPerson(int personId)
        {
            var addresses = Context.Address.Where(a => a.PersonId == personId).ToList();
            return addresses;
        }
    }
}
