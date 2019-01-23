using System;
using System.Collections.Generic;

namespace UserManagement.DAL.Models
{
    public partial class Person
    {
        public Person()
        {
            Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}
