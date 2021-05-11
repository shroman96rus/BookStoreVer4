using BookStoreVer4.Interfaces;
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

        public IActionResult Basket()
        {
            var model = Buys.get().Where(i => i.Client.email == User.Identity.Name);
            return View(model);
        }
    }
}
