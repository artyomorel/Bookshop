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
            if (book.ShowcaseId != null && !ValidateShowCase(book))
            {
                return false;
            }
            _bookRepository.Add(book);
            return true;

        }

        private bool ValidateShowCase(Book book)
        {
            var showcase = _showcaseRepository.GetById(book.ShowcaseId);
            if (showcase == null || TooManySize(book,showcase))
            {
                return false;
            }
            return true;
        }

        private bool TooManySize(Book book,Showcase showcase)
        {
            return _showcaseRepository.GetFreeSize(showcase.Id) - book.Size < 0;
        }

    }
}