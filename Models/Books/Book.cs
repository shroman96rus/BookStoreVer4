using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.Models.Books
{
    public class Book
    {
        public int bookId { get; set; }

        public int authorId { get; set; }

        public int genreId { get; set; }

        public string title { get; set; }

        public string bookDescription { get; set; }

        public string imagePath { get; set; }

        public decimal price { get; set; }

        public int amout { get; set; }

        public virtual Author Author { get; set; }

        public virtual Genre Genre { get; set; }

    }
}
