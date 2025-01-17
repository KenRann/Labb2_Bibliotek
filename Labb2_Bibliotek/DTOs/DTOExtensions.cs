using Humanizer;
using Labb2_Bibliotek.Classes;
using Labb2_Bibliotek.DTO;

namespace Labb2_Bibliotek.DTOs
{
    public static class DTOExtensions
    {
        public static Book ToBook(this CreateBookDTO createBookDto)
        {
            return new Book
            {
                Title = createBookDto.Title,
                Genre = createBookDto.Genre,
                Isbn = createBookDto.Isbn,
                ReleaseYear = createBookDto.ReleaseYear,
                Author = createBookDto.Author,
                
            };
        }

        public static BookDTO ToBookDTO(this Book book)
        {
            return new BookDTO
            {
                Title = book.Title,
                Genre = book.Genre,
                Isbn = book.Isbn,
                ReleaseYear = book.ReleaseYear,
                IsCheckedOut = book.IsCheckedOut,
                Rating = book.Rating,
            };
        }

        public static Book AddBook(this AddBookToAuthorDTO addBookToAuthorDto)
        {
            return new Book
            {
                Title = addBookToAuthorDto.Title,
                Genre = addBookToAuthorDto.Genre,
                ReleaseYear = addBookToAuthorDto.ReleaseYear,
                Isbn= addBookToAuthorDto.Isbn,
            };
        }

        public static Author ToAuthor(this CreateAuthorDTO createAuthorDto)
        {
            return new Author
            {
                Name = createAuthorDto.Name,
                Books = createAuthorDto.Books?.Select(b => new Book { Title = b.Title, Isbn = b.Isbn, ReleaseYear = b.ReleaseYear, Genre = b.Genre }).ToList() ?? new List<Book>()
            };
        }
    }
}
