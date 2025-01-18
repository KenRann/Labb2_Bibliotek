using Labb2_Bibliotek.Classes;

namespace Labb2_Bibliotek.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Isbn { get; set; }
        public required int ReleaseYear { get; set; }
        public required string Genre { get; set; }
        public int? Rating { get; set; }
        public bool IsCheckedOut { get; set; } = false;

        public ICollection<AuthorDTO>? Authors { get; set; } = new List<AuthorDTO>();
    }
}
