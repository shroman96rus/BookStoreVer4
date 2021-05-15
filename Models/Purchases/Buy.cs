using BookStoreVer4.Models.Books;
using BookStoreVer4.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.Models.Purchases
{
    public class Buy
    {
        public int buyid { get; set; }

        public int bookId { get; set; }

        public int clientid { get; set; }

        public int cityid { get; set; }

        public int stepid { get; set; }

        public string buyDescription { get; set; }

        public int amount { get; set; }

        public virtual Book Book { get; set; }

        public virtual Client Client { get; set; }

        public virtual City City { get; set; }

        public virtual Steps Steps { get; set; }
    }
}
