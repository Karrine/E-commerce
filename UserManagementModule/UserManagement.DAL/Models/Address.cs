using System;
using System.Collections.Generic;

namespace UserManagement.DAL.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string Locality { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public int PersonId { get; set; }

        public Person Person { get; set; }
    }
}
