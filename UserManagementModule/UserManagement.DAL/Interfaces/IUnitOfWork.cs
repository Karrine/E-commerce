using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository personRepository { get; }
        IAddressRepository addressRepository { get; }
        void Commit();

    }
}
