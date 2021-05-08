using BookStoreVer4.Database;
using BookStoreVer4.Interfaces;
using BookStoreVer4.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.Repositories
{
    public class ClientsRepository : IClients
    {
        private readonly BookStoreContext context;

        public ClientsRepository(BookStoreContext context)
        {
            this.context = context;
        }

        public void Create(Client client)
        {
            if(GetClient(client.clientid) == null)
            {
                context.clients.Add(client);
                context.SaveChanges();
            }
        }

        //Будут реализованы позже
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        //Будут реализованы позже
        public IEnumerable<Client> get()
        {
            return context.clients;
        }

        public Client GetClient(int id)
        {
            return context.clients.Find(id);
        }
    }
}
