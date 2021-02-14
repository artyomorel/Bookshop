using Bookshop.Domain.Interface;
using Bookshop.Domain.Models;

namespace Bookshop.BussinesLogic.Services
{
    public class BookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository  repository)
        {
            _repository = repository;
        }

        public bool Add(Book book)
        {
            _repository.Add(book);
            return true;
        }

    }
}