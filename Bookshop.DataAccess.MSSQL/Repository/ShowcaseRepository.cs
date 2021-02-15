using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Bookshop.Domain.Interface;
using Bookshop.Domain.Models;

namespace Bookshop.DataAccess.MSSQL.Repository
{
    public class ShowcaseRepository: IShowcaseRepository
    {
        private readonly BookshopContext _context;
        private readonly IMapper _mapper;

        public ShowcaseRepository(BookshopContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public void Add(Showcase showcase)
        {
            var newEntitiesShowcase = _mapper.Map<Entities.Showcase>(showcase);
            _context.Add(newEntitiesShowcase);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Remove(new Showcase {Id = id});
            _context.SaveChanges();
        }

        public void Update(Showcase showcase)
        {
            var newEntitiesShowcase = _mapper.Map<Entities.Showcase>(showcase);
            _context.Update(newEntitiesShowcase);
            _context.SaveChanges();
        }

        public List<Showcase> GetAll()
        {
            var newDomainShowcases = _mapper.Map<List<Showcase>>(_context.Showcases);
            return newDomainShowcases;
        }

        public Showcase GetById(int? id)
        {
            var showcase = _context.Showcases.FirstOrDefault(x=>x.Id == id);
            var newShowcase = _mapper.Map<Showcase>(showcase);
            return newShowcase;
        }

        public int GetFreeSize(int id)
        {
            var currentSize = _context.Books.Where(x => x.ShowcaseId == id).Sum(x => x.Size);
            var totalSize = GetById(id).TotalSize;
            return totalSize - currentSize;
        }
    }
}