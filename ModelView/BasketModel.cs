using BookStoreVer4.Models.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.ModelView
{
    public class BasketModel
    {
        public IEnumerable<Buy> orderBuys { get; set; }

        public decimal summOrdersClient { get; set; }
    }
}
