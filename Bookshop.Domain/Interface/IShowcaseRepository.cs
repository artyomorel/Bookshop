using System.Collections.Generic;
using Bookshop.Domain.Models;

namespace Bookshop.Domain.Interface
{
    public interface IShowcaseRepository
    {
        void Add(Showcase showcase);
        void Delete(int id);
        void Update(Showcase showcase);
        List<Showcase> GetAll();
        Showcase GetById(int id);
    }
}