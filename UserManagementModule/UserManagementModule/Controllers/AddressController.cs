using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManagement.DAL.Models;
using UserManagement.Server.Services.AddressService;

namespace UserManagement.Server.Controllers
{
    [Route("api/address")]
    public class AddressController : Controller
    {
        public IAddressService addressService = null;
        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("useraddresses/{personId}")]
        public IActionResult GetPersonAddresses(int personId)
        {
            var addresses = addressService.GetAddressesForPerson(personId);
            return Ok(addresses);
        }

        [Route("adduseraddress")]
        public IActionResult AddPersonAddress([FromBody] Address address)
        {
            addressService.CreateAddress(address);
            return Ok("Address added.");

        }
        [HttpGet]
        [Route("/getall")]
        public IActionResult GetAllAddresses()
        {
            var list = addressService.GetAddresses();
            return Ok(list);
        }

        [Route("/delete/{addressId}")]
        public IActionResult DeleteAddress([FromRoute] int addressId)
        {
            addressService.DeleteAddress(addressId);
            return Ok("Done");
        }

    }
}