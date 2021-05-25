using BookStoreVer4.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.ModelView
{
    public class HomeIndexModel
    {
        public IEnumerable<Book> books;

        public IEnumerable<Author> authors;

        public IEnumerable<Genre> genres;

    }
}
