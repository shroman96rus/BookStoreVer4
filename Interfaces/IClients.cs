using BookStoreVer4.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.Interfaces
{
    public interface IClients
    {
        public void Create(Client client);
        public void Delete(int id);
        public Client GetClient(int id);
        public IEnumerable<Client> get();
    }
}
