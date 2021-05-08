using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.Controllers
{
    public class BuyController : Controller
    {
        public IActionResult Order()
        {

            return View();
        }
    }
}
