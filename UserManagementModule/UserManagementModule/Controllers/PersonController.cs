using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManagement.DAL.Models;
using UserManagement.Server.Aggregates;
using UserManagement.Server.Services.PersonService;

namespace UserManagement.Server.Controllers
{
    [Route("api/people")]
    public class PersonController : Controller
    {
        private IPersonService personService = null;
        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllPeople()
        {
            var list = personService.GetPeople();
            return Ok(list);
        }

        [Route("/create")]
        public IActionResult CreateAccount([FromBody] Person person)
        {
            try
            {
                personService.AddPerson(person);
            }
            catch (Exception e)
            {
                return Ok(e.Message.ToString());
            }
            return Ok();

        }

        [HttpGet]
        [Route("login")]
        public IActionResult LogIn([FromBody] User user)
        {
            var pers = personService.CheckAccount(user);
            if(pers == null)
            {
                return NotFound("User not found");
            }
            return Ok(pers);
        }
        [HttpGet]
        [Route("user/{personId}")]
        public IActionResult GetUserDetails([FromRoute] int personId)
        {
            var person = personService.GetPersonDetails(personId);
            return Ok(person);
        }
    }
}