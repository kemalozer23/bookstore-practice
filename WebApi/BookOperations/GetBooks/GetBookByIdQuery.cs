using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public int BookId { get; set; }
        public GetBookByIdQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookViewModel Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);

            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı");

            BookViewModel Model = new BookViewModel();

            Model.Title = book.Title;
            Model.Genre = ((GenreEnum)book.GenreId).ToString();
            Model.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
            Model.PageCount = book.PageCount;

            return Model;
        }


    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}