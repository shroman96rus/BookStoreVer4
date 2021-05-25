using BookStoreVer4.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.Interfaces
{
    public interface IBooks
    {
        public IQueryable<Book> get();

        public Book GetBook(int id);

        public void createBook(Book book);

        public void updateBook(int id);

        public void deleteBook(int id);

        public IEnumerable<Author> getAuthors();

        public IEnumerable<Genre> getGenres();
    }
}
