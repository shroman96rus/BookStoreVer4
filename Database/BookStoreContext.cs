using BookStoreVer4.Models.Books;
using BookStoreVer4.Models.Clients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.Database
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base (options)
        { }

        //Подключение к таблицам относящимся к кигам
        public DbSet<Author> authors { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Genre> genres { get; set; }

        //Подключение к таблице клиентов
        public DbSet<Client> clients { get; set; }
    }
}
