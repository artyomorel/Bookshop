using System.Collections.Generic;
using System.Linq;
using Bookshop.Domain.Interface;
using Bookshop.Domain.Models;

namespace Bookshop.BussinesLogic.Services
{
    public class ShowcaseService : IShowcaseService
    {
        private readonly IShowcaseRepository _showcaseRepository;
        private readonly IBookRepository _bookRepository;

        public ShowcaseService(IShowcaseRepository showcaseRepository,IBookRepository bookRepository)
        {
            _showcaseRepository = showcaseRepository;
            _bookRepository = bookRepository;
        }

        public bool Add(Showcase showcase)
        {
            _showcaseRepository.Add(showcase);
            return true;
        }

        public bool Delete(int id)
        {
            var showcase = _showcaseRepository.GetById(id);
            if (showcase == null)
            {
                return false;
            }
            _showcaseRepository.Delete(id);
            return true;
        }
        
        public List<Showcase> GetAll()
        {
            return _showcaseRepository.GetAll();
        }

        public Showcase Get(int id)
        {
            return _showcaseRepository.GetById(id);
        }



        public bool Update(Showcase showcase)
        {
            var showcaseFromDatabase = _showcaseRepository.GetById(showcase.Id);
            if (showcaseFromDatabase == null)
            {
                return false;
            }
            var currentTakenSize = _bookRepository.GetBooksFromShowcase(showcase.Id).Sum(x=>x.Size);
            if (currentTakenSize > showcase.TotalSize)
            {
                return false;
            }
            
            _showcaseRepository.Update(showcase);
            return true;
        }
        
    }
}