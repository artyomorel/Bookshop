using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using Bookshop.BussinesLogic.Exceptions;
using Bookshop.Domain.Interface;
using Bookshop.Domain.Models;

namespace Bookshop.BussinesLogic.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IShowcaseRepository _showcaseRepository;

        public BookService(IBookRepository bookRepository,IShowcaseRepository showcaseRepository)
        {
            _bookRepository = bookRepository;
            _showcaseRepository = showcaseRepository;
        }

        public bool Add(Book book)
        {
            if (!CheckValidateShowcase(book)) throw new ValidateShowcase($"Showcase with {book.ShowcaseId} not validate");
            _bookRepository.Add(book);
            return true;

        }

        private bool CheckValidateShowcase(Book book)
        {
            var showcase = _showcaseRepository.GetById(book.ShowcaseId);
            return book.ShowcaseId == null || (showcase != null && IsFreeSpace(book,showcase)) ;
        }
        private bool IsFreeSpace(Book book,Showcase showcase)
        {
            return _showcaseRepository.GetFreeSize(showcase.Id) - book.Size >= 0;
        }
        
        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public bool Delete(int id)
        {
           var book = _bookRepository.GetById(id);
           if (book == null)
           {
               throw new NotFoundException($"Book with {id} not found");
           }
           _bookRepository.Delete(id);
           return true;
        }

        public bool Update(Book book)
        {
            var bookFromDatabase = _bookRepository.GetById(book.Id);
            if (bookFromDatabase == null)
            {
                throw new NotFoundException($"Book with {book.Id} not found");
            }

            if (!CheckValidateShowcase(book))
            {
                throw new ValidateShowcase($"Showcase with {book.ShowcaseId} not validate");
            }
                
            _bookRepository.Update(book);
            return true;
            

        }
    }
}