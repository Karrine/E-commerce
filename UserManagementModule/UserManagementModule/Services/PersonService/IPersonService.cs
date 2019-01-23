using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Server.Aggregates;

namespace UserManagement.Server.Services.PersonService
{
    public interface IPersonService
    {
        DAL.Models.Person GetPersonDetails(int personId);
        void AddPerson(DAL.Models.Person person);
        void UpdatePerson(DAL.Models.Person person);
        IEnumerable<DAL.Models.Person> GetPeople();
        void DeletePerson(int personId);
        int? CheckAccount(User user);
    }
}
