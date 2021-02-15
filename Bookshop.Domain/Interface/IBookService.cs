using System.Collections.Generic;
using Bookshop.Domain.Models;

namespace Bookshop.Domain.Interface
{
    public interface IBookService
    {
        bool Add(Book book);
        List<Book> GetAll();
        Book GetById(int id);
        bool Delete(int id);
        bool Update(Book book);
    }
}