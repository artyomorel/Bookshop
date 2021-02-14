using System.Collections.Generic;
using Bookshop.Domain.Interface;
using Bookshop.Domain.Models;

namespace Bookshop.DataAccess.MSSQL.Repository
{
    public class BookRepository: IBookRepository
    {
        private readonly BookshopContext _context;

        public BookRepository(BookshopContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            throw new System.NotImplementedException();
        }

        public Book GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Book> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Book book)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}