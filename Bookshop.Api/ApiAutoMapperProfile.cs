using AutoMapper;
using Bookshop.Api.Models;
using Bookshop.Domain.Models;

namespace Bookshop.Api
{
    public class ApiAutoMapperProfile : Profile
    {
        public ApiAutoMapperProfile()
        {
            CreateMap<CreateBookRequest, Book>();
            CreateMap<Book, BookDto>();
        }
    }
}