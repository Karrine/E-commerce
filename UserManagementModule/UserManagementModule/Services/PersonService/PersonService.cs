using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.DAL.Interfaces;
using UserManagement.DAL.Models;
using UserManagement.Server.Aggregates;

namespace UserManagement.Server.Services.PersonService
{
    public class PersonService : IPersonService
    {
        public IUnitOfWork unitOfWork = null;

        public PersonService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddPerson(Person person)
        {
            if (unitOfWork.personRepository.CheckUsernameAvailability(person.Email))
            {

                unitOfWork.personRepository.Create(person);
                unitOfWork.Commit();
            }
            else
            {
                throw new Exception($"An account for email: {person.Email} already exists");
            }
        }

        public int? CheckAccount(User user)
        {
            var response = unitOfWork.personRepository.CheckAccount(user.Email, user.Password);
            return response;
        }

        public void DeletePerson(int personId)
        {
            unitOfWork.personRepository.Detele(personId);
            unitOfWork.Commit();
        }

        public IEnumerable<Person> GetPeople()
        {
            var list = unitOfWork.personRepository.GetAll();
            return list;
        }

        public Person GetPersonDetails(int personId)
        {
            var person = unitOfWork.personRepository.Details(personId);
            return person;
        }

        public void UpdatePerson(Person person)
        {
            unitOfWork.personRepository.Edit(person);
            unitOfWork.Commit();
        }
    }
}
