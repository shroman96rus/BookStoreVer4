using BookStoreVer4.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBooks Books;

        public HomeController(IBooks books)
        {
            Books = books;
        }

        public IActionResult Index()
        {
            var model = Books.get();
            return View(model);
        }

        public IActionResult BookDetail(int id)
        {
            var model = Books.GetBook(id);
            return View(model);
        }

        public IActionResult BuyBook(int id)
        {
            var model = Books.GetBook(id);
            return View(model);
        }
    }
}
