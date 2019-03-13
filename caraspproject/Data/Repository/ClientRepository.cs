using caraspproject.Data.Interfaces;
using caraspproject.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caraspproject.Data.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
