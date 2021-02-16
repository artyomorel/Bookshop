using System.Collections.Generic;
using Bookshop.Domain.Models;

namespace Bookshop.Domain.Interface
{
    public interface IShowcaseService
    {
        bool Add(Showcase showcase);
        bool Delete(int id);
        List<Showcase> GetAll();
        Showcase Get(int id);
        bool Update(Showcase showcase);
    }
}