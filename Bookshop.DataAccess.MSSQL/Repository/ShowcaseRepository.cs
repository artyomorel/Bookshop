using System.Collections.Generic;
using Bookshop.Domain.Interface;
using Bookshop.Domain.Models;

namespace Bookshop.DataAccess.MSSQL.Repository
{
    public class ShowcaseRepository: IShowcaseRepository
    {
        private readonly BookshopContext _context;

        public ShowcaseRepository(BookshopContext context)
        {
            _context = context;
        }
        
        public void Add(Showcase showcase)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Showcase showcase)
        {
            throw new System.NotImplementedException();
        }

        public List<Showcase> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Showcase GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}