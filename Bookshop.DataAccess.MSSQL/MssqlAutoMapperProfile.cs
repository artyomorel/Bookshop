using AutoMapper;
using Bookshop.Domain.Models;

namespace Bookshop.DataAccess.MSSQL
{
    public class MssqlAutoMapperProfile: Profile
    {
        public MssqlAutoMapperProfile()
        {
            CreateMap<Book, Entities.Book>().ReverseMap();
            CreateMap<Showcase, Entities.Showcase>().ReverseMap();
        }
    }
}