using AutoMapper;
using WebApi.BookOperations.GetBooks;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            
            CreateMap<UpdateBookModel, Book>().ForAllMembers(opt => opt.Ignore());
            CreateMap<UpdateBookModel, Book>().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<UpdateBookModel, Book>().ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId));
        }
    }
}