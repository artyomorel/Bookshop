using System.Collections.Generic;
using Bookshop.Domain.Models;

namespace Bookshop.Domain.Interface
{
    public interface IBookRepository
    {
        void Add(Book book);
        Book GetById(int id);
        List<Book> GetAll();
        void Update(Book book);
        void Delete(int id);
    }
}