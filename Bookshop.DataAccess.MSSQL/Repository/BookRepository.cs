using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Bookshop.Domain.Interface;
using Bookshop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookshop.DataAccess.MSSQL.Repository
{
    public class BookRepository: IBookRepository
    {
        private readonly BookshopContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookshopContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(Book book)
        {
            var newBook = _mapper.Map<Entities.Book>(book);
            _context.Add(newBook);
            _context.SaveChanges();
        }

        public Book GetById(int id)
        {
            var entitiesBook = _context.Books.AsNoTracking().FirstOrDefault(x => x.Id == id);
            var newDomainBook = _mapper.Map<Book>(entitiesBook);
            return newDomainBook;
        }

        public List<Book> GetAll()
        {
            var books = _context.Books.AsNoTracking().ToList();
            var newBooks = _mapper.Map<List<Book>>(books);
            return newBooks;
        }

        public void Update(Book book)
        {
            var newBook = _mapper.Map<Entities.Book>(book);
            _context.Update(newBook);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Books.Remove(new Entities.Book {Id = id});
            _context.SaveChanges();
        }
    }
}