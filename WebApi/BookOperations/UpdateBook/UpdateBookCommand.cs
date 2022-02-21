using WebApi.Common;
using WebApi.DbOperations;
using AutoMapper;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public int BookId { get; set; }
        public UpdateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public UpdateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);

            if(book is null)
                throw new InvalidOperationException("Kitap mevcut değil");

            // book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            // book.Title = Model.Title != default ? Model.Title : book.Title;

            book = _mapper.Map<Book>(Model);

            _dbContext.Books.Update(book);

            _dbContext.SaveChanges();
        }
        
        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
        }
    }
}