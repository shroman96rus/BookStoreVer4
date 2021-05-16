using BookStoreVer4.Models.Books;
using BookStoreVer4.Models.Clients;
using BookStoreVer4.Models.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.ModelView
{
    public class OrderModel
    {
        public Book changeBook { get; set; }

        public int bookAmount { get; set; }

        public Client client { get; set; }

        public IEnumerable<City> cities { get; set; }

        public Buy order { get; set; }

    }
}
