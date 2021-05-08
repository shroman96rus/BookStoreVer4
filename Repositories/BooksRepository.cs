using BookStoreVer4.Database;
using BookStoreVer4.Interfaces;
using BookStoreVer4.Models.Books;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.Repositories
{
    public class BooksRepository : IBooks
    {
        private readonly BookStoreContext context;
        public BooksRepository(BookStoreContext context)
        {
            this.context = context;
            context.books.Include(i => i.Author).Load();
            context.books.Include(i => i.Genre).Load();
        }

        public void createBook(Book book)
        {
            
                context.books.Add(book);
                context.SaveChanges();
            
        }

        public void deleteBook(int id)
        {
            context.books.Remove(GetBook(id));
            context.SaveChanges();
        }

        public IQueryable<Book> get()
        {
           
            return context.books;
        }

        public Book GetBook(int id)
        {
            return context.books.Find(id);
        }

        public void updateBook(int id)
        {
            context.books.Attach(GetBook(id)).State = EntityState.Modified;

        }
    }
}
