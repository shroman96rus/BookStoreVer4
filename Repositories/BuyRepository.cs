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
            context.buy.Include(i => i.Book.Author).Load();
            context.buy.Include(i => i.Book.Genre).Load();
            context.buy.Include(i => i.Steps).Load();
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

        public IQueryable<Buy> get()
        {
            return context.buy;
        }

        public IQueryable<City> GetCities()
        {
            return context.cities;
        }
    }
}
