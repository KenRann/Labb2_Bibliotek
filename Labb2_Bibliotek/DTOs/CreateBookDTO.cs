using Labb2_Bibliotek.Classes;

namespace Labb2_Bibliotek.DTO
{
    public class CreateBookDTO
    {
        public required string Title { get; set; }
        public string? Isbn { get; set; }
        public bool IsCheckedOut { get; set; } = false;
        public int ReleaseYear { get; set; }
        public required string Genre { get; set; }
        public int Rating { get; set; }

        public ICollection<Author> Author { get; set; } = new List<Author>();
    }
}
