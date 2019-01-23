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
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private UserManagementContext Context
        {
            get
            {
                return db as UserManagementContext;
            }
        }
        public PersonRepository(UserManagementContext context) : base(context)
        {

        }

        public void Create(Person entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public Person Details(int personId)
        {
            var person = Context.Person.SingleOrDefault(p => p.Id == personId);
            return person;

        }

        public void Edit(Person entity)
        {
            Context.Person.Update(entity);
            Context.SaveChanges();

        }

        public void Detele(int personId)
        {
            var person = Context.Person.SingleOrDefault(p => p.Id == personId);
            if(person != null)
            {
                Context.Person.Remove(person);
                Context.SaveChanges();
            }
        }

        public IEnumerable<Person> GetAll()
        {
            var people = Context.Person.ToList();
            return people;

        }

        public int? CheckAccount(string email, string password)
        {
            var user = Context.Person.SingleOrDefault(p => p.Email.Equals(email));
            if(user != null)
            {
                if (user.Password.Equals(password))
                {
                    return user.Id;
                }
            }
            return null;
        }

        public bool CheckUsernameAvailability(string email)
        {
            var user = Context.Person.Where(p => p.Email.Equals(email));
            if(user == null)
            {
                return true;
            }
            return false;
        }
    }
}
