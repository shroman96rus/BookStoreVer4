using BookStoreVer4.Interfaces;
using BookStoreVer4.Models.Books;
using BookStoreVer4.Models.Purchases;
using BookStoreVer4.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.Controllers
{
    [Authorize(Policy = "saller")]
    [Authorize(Policy = "Client")]
    public class SallerController : Controller
    {
       
        private readonly IBooks Books;
        private readonly IBuy Buy;
        readonly IWebHostEnvironment _appEnvironment;
        

        public SallerController(IBooks Books, IWebHostEnvironment appEnvironment, IBuy Buy)
        {
            this.Books = Books;
            _appEnvironment = appEnvironment;
            this.Buy = Buy;
        }

        public IActionResult Index()
        {
            var model = Books.get();
            
            return View(model);
        }

        public IActionResult CreateBook()
        {
            CreateBookModel model = new CreateBookModel()
            {
                authors = Books.getAuthors(),
                genres = Books.getGenres()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(Book book, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                if (uploadedFile != null)
                {
                    string path = "/img/books/" + uploadedFile.FileName;
                    using (FileStream fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    book.imagePath = path;
                }

                    if (Books.GetBook(book.bookId) == null)
                {
                    if (book.Author != null)
                    {
                        book.Author.authorId = Books.getAuthors().Count() + 1;
                        book.authorId = book.Author.authorId;
                    }
                    if (book.Genre != null)
                    {
                        book.Genre.genreId = Books.getGenres().Count() + 1;
                        book.genreId = book.Genre.genreId;
                    }
                    Books.createBook(book);

                }
            }
            return RedirectToAction("Index", "Saller");
        }

        public IActionResult OrdersPaid()
        {
            var model = Buy.get();
            return View(model);
        }

        public IActionResult OrderDetail(int id, string step)
        {
            var model = Buy.GetOrder(id);

            if (step != null)
            {
                switch (step)
                {
                    case "Упакован": model.stepid = 6; Buy.UpdateBuyStep(model);  break;
                    case "Отправлен": model.stepid = 3; Buy.UpdateBuyStep(model); break;
                    case "Прибыл": model.stepid = 4; Buy.UpdateBuyStep(model); break;
                    case "Доставлен": model.stepid = 5; Buy.UpdateBuyStep(model); break;
                    default:
                        break;
                }
            }

            
            return View(model);
        }

    }
}
