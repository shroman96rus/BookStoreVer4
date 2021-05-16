using BookStoreVer4.Models.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.Interfaces
{
    public interface IBuy
    {
        public void CreateOrder(Buy buy);

        public Buy GetOrder(int id);

        public IEnumerable<Buy> get();

        public IEnumerable<City> GetCities();

        public void UpdateBuy(int id);
    }
}
