using BookStoreVer4.Interfaces;
using BookStoreVer4.ModelView;
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

        public IActionResult Index(string sort)
        {
            HomeIndexModel model = new HomeIndexModel();
            
            model.books = Books.get();

            model.authors = Books.getAuthors();

            model.genres = Books.getGenres();

            if (!string.IsNullOrEmpty(sort))
            {
                foreach (var item in Books.getGenres())
                {
                    if (sort == item.nameGenre)
                    {
                        model.books = Books.get().Where(i => i.Genre.nameGenre == item.nameGenre);
                    }
                }

            }
           

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
