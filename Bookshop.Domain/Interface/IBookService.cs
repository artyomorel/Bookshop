using Bookshop.Domain.Models;

namespace Bookshop.BussinesLogic.Services
{
    public interface IBookService
    {
        bool Add(Book book);
    }
}