using Labb2_Bibliotek.Classes;

namespace Labb2_Bibliotek.DTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public string? Isbn { get; set; }
        public int ReleaseYear { get; set; }
        public string? Genre { get; set; }
        public int? Rating { get; set; }
        public bool IsCheckedOut { get; set; } = false;

        public ICollection<AuthorDTO>? Authors { get; set; } = new List<AuthorDTO>();
    }
}
