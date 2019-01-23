using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.DAL.Models;

namespace UserManagement.DAL.Interfaces
{
    public interface IPersonRepository
    {
        void Create(Person entity);
        Person Details(int personId);
        void Edit(Person entity);
        void Detele(int personId);
        IEnumerable<Person> GetAll();
        int? CheckAccount(string email, string password);
        Boolean CheckUsernameAvailability(string email);
        
    }
}
