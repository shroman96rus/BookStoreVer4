﻿using BookStoreVer4.Interfaces;
using BookStoreVer4.Models.Purchases;
using BookStoreVer4.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.Controllers
{
    [Authorize(Policy = "saller")]
    [Authorize(Policy = "Client")]
    public class BasketController : Controller
    {
        readonly IBuy Buys;

        public BasketController(IBuy Buys)
        {
            this.Buys = Buys;
        }

       

        public IActionResult Basket()
        {
            
            decimal summOers = 0;

            foreach (var item in Buys.get().Where(i => (i.Client.email == User.Identity.Name) && (i.stepid == 1)))
            {
                summOers = summOers + (item.Book.price * item.amount);
            }

            BasketModel model = new BasketModel
            {
                orderBuys = Buys.get().Where(i => (i.Client.email == User.Identity.Name) && (i.stepid == 1)),
                summOrdersClient = summOers
            };
            //var model = Buys.get().Where(i => i.Client.email == User.Identity.Name);
            return View(model);
        }

        public IActionResult BasketConfirm(int id)
        {
            var test = Buys.GetOrder(id);
            test.stepid = 2;
            Buys.UpdateBuy(test);

            return RedirectToAction("Index", "Home");
        }
    }
}
