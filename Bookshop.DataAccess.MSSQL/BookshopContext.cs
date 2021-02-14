using Bookshop.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookshop.DataAccess.MSSQL
{
    public class BookshopContext: DbContext
    {
        public BookshopContext(DbContextOptions<BookshopContext> options):base(options)
        { }
        
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Showcase> Showcases { get; set; }
    }
}