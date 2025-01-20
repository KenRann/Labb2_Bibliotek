using System.Text.Json.Serialization;

namespace Labb2_Bibliotek.Classes
{
    public class Book
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public string? Isbn { get; set; }
        public bool IsCheckedOut { get; set; } = false;
        public int ReleaseYear { get; set; }
        public string? Genre { get; set; }
        public int? Rating { get; set; }

        public ICollection<Author> Author { get; set; } = new List<Author>();
    }
}
