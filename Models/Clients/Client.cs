using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.Models.Clients
{
    public class Client
    {
        public int clientid { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string clientPassword { get; set; }

        public string email { get; set; }

        public int phoneNumber { get; set; }
    }
}
