using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.DAL.Models;

namespace UserManagement.DAL.Interfaces
{
    public interface IAddressRepository
    {
        void Create(Address address);
        void Edit(Address address);
        Address Details(int addressId);
        void Delete(int addressId);
        IEnumerable<Address> GetAll();
        IEnumerable<Address> GetAddressesForPerson(int personId);

    }
}
