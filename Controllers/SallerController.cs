using BookStoreVer4.Interfaces;
using BookStoreVer4.Models.Books;
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
    public class SallerController : Controller
    {
       
        private readonly IBooks Books;
        readonly IWebHostEnvironment _appEnvironment;

        public SallerController(IBooks Books, IWebHostEnvironment appEnvironment)
        {
            this.Books = Books;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            var model = Books.get();
            return View(model);
        }

        public IActionResult CreateBook()
        {
            return View();
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
                    Books.createBook(book);

                }
            }
            return RedirectToAction("Index", "Saller");
        }

    }
}
