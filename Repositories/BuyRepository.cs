using BookStoreVer4.Database;
using BookStoreVer4.Interfaces;
using BookStoreVer4.Models.Purchases;
using Microsoft.EntityFrameworkCore;
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
            context.buy.Include(i => i.Book).Load();
            context.buy.Include(i => i.City).Load();
            context.buy.Include(i => i.Client).Load();
            //context.buy.Include(i => i.Book.Author).Load();
            //context.buy.Include(i => i.Book.Genre).Load();
            context.buy.Include(i => i.Step).Load();
        }

        public void CreateOrder(Buy buy)
        {
            context.buy.Add(buy);
            context.SaveChanges();
        }

        public Buy GetOrder(int id)
        {
            return context.buy.Find(id);
        }

        public IEnumerable<Buy> get()
        {
            return context.buy;
        }

        public void UpdateBuy(Buy buy)
        {
            context.buy.Attach(buy).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void UpdateBuyStep(Buy buy)
        {
            context.buy.Attach(buy).State = EntityState.Modified;
            context.SaveChanges();
            context.buy.Include(i => i.Step).Load();
        }

        public IEnumerable<City> GetCities()
        {
            return context.cities;
        }

        public IEnumerable<Step> GetStep()
        {
            return context.steps;
        }
    }
}
