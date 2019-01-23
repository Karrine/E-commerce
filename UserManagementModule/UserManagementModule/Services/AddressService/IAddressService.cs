using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Server.Services.AddressService
{
    public interface IAddressService
    { 
        DAL.Models.Address GetAddress(int addressId);
        void CreateAddress(DAL.Models.Address address);
        void EditAddress(DAL.Models.Address address);
        void DeleteAddress(int addressId);
        IEnumerable<DAL.Models.Address> GetAddresses();
        IEnumerable<DAL.Models.Address> GetAddressesForPerson(int personId);

    }
}
