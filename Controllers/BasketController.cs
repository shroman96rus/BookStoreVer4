using BookStoreVer4.Interfaces;
using BookStoreVer4.Models.Purchases;
using BookStoreVer4.ModelView;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.Controllers
{
    public class BasketController : Controller
    {
        readonly IBuy Buys;

        public BasketController(IBuy Buys)
        {
            this.Buys = Buys;
        }

        //public IQueryable<Buy> clientBuys 
        //{
        //    get 
        //    {
        //     return Buys.get().Where(i => i.Client.email == User.Identity.Name);
        //    }
            
        //}

        public IActionResult Basket()
        {
            
            decimal summOers = 0;

            foreach (var item in Buys.get().Where(i => i.Client.email == User.Identity.Name))
            {
                summOers = summOers + (item.Book.price * item.amount);
            }

            BasketModel model = new BasketModel
            {
                orderBuys = Buys.get().Where(i => i.Client.email == User.Identity.Name),
                summOrdersClient = summOers
            };
            //var model = Buys.get().Where(i => i.Client.email == User.Identity.Name);
            return View(model);
        }

        public IActionResult BasketConfirm(string test)
        {
            if (test != null)
            {
                foreach (var item in Buys.get().Where(i => i.Client.email == User.Identity.Name))
                {
                    item.stepid = 2;

                    Buys.UpdateBuy(item.buyid);
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
