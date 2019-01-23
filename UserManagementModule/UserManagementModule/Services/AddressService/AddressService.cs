using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.DAL.Interfaces;
using UserManagement.DAL.Models;

namespace UserManagement.Server.Services.AddressService
{
    public class AddressService : IAddressService
    {
        public IUnitOfWork unitOfWork = null;
        public AddressService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void CreateAddress(Address address)
        {
            unitOfWork.addressRepository.Create(address);
            unitOfWork.Commit();
        }

        public void DeleteAddress(int addressId)
        {
            var address = unitOfWork.addressRepository.Details(addressId);
            if(address != null)
            {
                unitOfWork.addressRepository.Delete(addressId);
                unitOfWork.Commit();
            }
        }

        public void EditAddress(Address address)
        {
            unitOfWork.addressRepository.Edit(address);
            unitOfWork.Commit();
        }

        public Address GetAddress(int addressId)
        {
            var address = unitOfWork.addressRepository.Details(addressId);
            return address;
        }

        public IEnumerable<Address> GetAddresses()
        {
            var addresses = unitOfWork.addressRepository.GetAll();
            return addresses;
        }

        public IEnumerable<Address> GetAddressesForPerson(int personId)
        {
            var personAddresses = unitOfWork.addressRepository.GetAddressesForPerson(personId);
            return personAddresses;
        }
    }
}
