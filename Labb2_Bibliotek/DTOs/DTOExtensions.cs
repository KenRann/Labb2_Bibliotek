using Humanizer;
using Labb2_Bibliotek.Classes;
using Labb2_Bibliotek.DTOs.CreateDTOs;
using Microsoft.CodeAnalysis.Operations;
using System.Reflection;

namespace Labb2_Bibliotek.DTOs
{
    public static class DTOExtensions
    {
        // -- Book --
        //Create
        public static Book ToBook(this CreateBookDTO createBookDto)
        {
            return new Book
            {
                Title = createBookDto.Title,
                Genre = createBookDto.Genre,
                Isbn = createBookDto.Isbn,
                ReleaseYear = createBookDto.ReleaseYear,
                Author = createBookDto.Author.Select(a => new Author { Name = a.Name }).ToList()
            };
        }

        // Read
        public static BookDTO ToBookDTO(this Book book)
        {
            return new BookDTO
            {
                BookId = book.BookId,
                Title = book.Title,
                Genre = book.Genre,
                Isbn = book.Isbn,
                ReleaseYear = book.ReleaseYear,
                IsCheckedOut = book.IsCheckedOut,
                Rating = book.Rating,
                Authors = book.Author.Select(a => new AuthorDTO { Name = a.Name, AuthorId = a.AuthorId }).ToList()
            };
        }

        // Add Book to Author
        public static Book AddBook(this AddBookToAuthorDTO addBookToAuthorDto)
        {
            return new Book
            {
                Title = addBookToAuthorDto.Title,
                Genre = addBookToAuthorDto.Genre,
                ReleaseYear = addBookToAuthorDto.ReleaseYear,
                Isbn= addBookToAuthorDto.Isbn
            };
        }

        // -- Author --
        //Create
        public static Author ToAuthor(this CreateAuthorDTO createAuthorDto)
        {
            return new Author
            {
                Name = createAuthorDto.Name             
            };
        }

        //Read
        public static AuthorDTO ToAuthorDto(this Author author)
        {
            return new AuthorDTO
            {
                Name = author.Name,
                AuthorId = author.AuthorId,
                Books = author.Books?.Select(b => new BookDTO
                {               
                    BookId = b.BookId,
                    Title = b.Title,
                    ReleaseYear= b.ReleaseYear,
                    Isbn = b.Isbn,
                    Genre= b.Genre,
                    Rating= b.Rating           
                }).ToList()
            };
        }

        // -- Members --
        //Create
        public static Member ToMember(this CreateMemberDTO createMemberDto)
        {
            return new Member
            {
                FirstName = createMemberDto.FirstName,
                LastName = createMemberDto.LastName,
                Email = createMemberDto.Email,
                Phone = createMemberDto.Phone,
                RegisteredMembership = DateTime.Now
            };
        }

        //Read
        public static MemberDTO ToMemberDto(this Member member)
        {
            return new MemberDTO
            {
                MemberId = member.MemberId,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
                Phone = member.Phone,
                RegisteredMembership = DateOnly.FromDateTime(member.RegisteredMembership)
            };
        }

        // -- BookCheckout --
        //Read
        public static BookCheckoutDTO ToBookCheckoutDTO(this BookCheckout bookCheckout)
        {
            return new BookCheckoutDTO
            {
                BookCheckoutId = bookCheckout.BookCheckoutId,               
                CheckedOutDate = bookCheckout.CheckedOutDate,
                ReturnDate = bookCheckout.ReturnDate,
                IsReturned = bookCheckout.IsReturned,
                Book = bookCheckout.Book,
                Member = new Member { 
                    MemberId = bookCheckout.Member.MemberId,
                    FirstName = bookCheckout.Member.FirstName,
                    LastName = bookCheckout.Member.LastName,
                    Email= bookCheckout.Member.Email,
                    Phone = bookCheckout.Member.Phone
                }
            };
        }
    }
}
