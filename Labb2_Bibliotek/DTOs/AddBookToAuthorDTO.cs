using Labb2_Bibliotek.Classes;

namespace Labb2_Bibliotek.DTOs
{
    public class AddBookToAuthorDTO
    {
        public required string Title { get; set; }
        public string? Isbn { get; set; }
        public required int ReleaseYear { get; set; }
        public required string Genre { get; set; }
    }
}
