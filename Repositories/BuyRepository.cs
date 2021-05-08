using BookStoreVer4.Database;
using BookStoreVer4.Interfaces;
using BookStoreVer4.Models.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.Repositories
{
    public class BuyRepository : IBuy
    {
        private readonly BookStoreContext context;

        public BuyRepository(BookStoreContext context)
        {
            this.context = context;
        }

        public void CreateOrder(Buy buy)
        {
            context.buys.Add(buy);
            context.SaveChanges();
        }

        public Buy GetOrder(int id)
        {
            return context.buys.Find(id);
        }

        public IQueryable<Buy> get()
        {
            return context.buys;
        }
    }
}
