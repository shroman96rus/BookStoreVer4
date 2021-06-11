using BookStoreVer4.Interfaces;
using BookStoreVer4.Models.Books;
using BookStoreVer4.Models.Clients;
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
    [Authorize(Policy = "saller")]
    public class BuyController : Controller
    {
        readonly IBuy Buys;
        readonly IClients clients;
        readonly IBooks Books;

        public BuyController(IBuy Buys, IClients clients, IBooks Books)
        {
            this.Buys = Buys;
            this.clients = clients;
            this.Books = Books;
        }

        public IActionResult Order(int id, int amount)
        {
            if (User.Identity.IsAuthenticated)
            {
                var book = Books.GetBook(id);

                Client person = clients.get().FirstOrDefault(i => i.email == User.Identity.Name);

                OrderModel model = new OrderModel
                {
                    changeBook = book,

                    client = person,

                    bookAmount = amount,

                    cities = Buys.GetCities()
                };
                return View(model);
            }
            else
            {
                RedirectToAction("Login", "Account");
            }
           
            return RedirectToAction("Index", "Home");
            
        }

        [HttpPost]
        public IActionResult Order(Buy order)
        {
            if (ModelState.IsValid)
            {
                order.stepid = 1;
                Buys.CreateOrder(order);
                Book buyBook = Books.GetBook(order.bookId);
                buyBook.amout = buyBook.amout -order.amount;
                Books.updateBook(buyBook.bookId);
                return RedirectToAction("Basket", "Basket");
            }
            return View();
        }

    }
}
