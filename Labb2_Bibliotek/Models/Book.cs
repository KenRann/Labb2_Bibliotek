using System.Text.Json.Serialization;

namespace Labb2_Bibliotek.Classes
{
    public class Book
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public string? Isbn { get; set; }
        public bool IsCheckedOut { get; set; } = false;
        public required int ReleaseYear { get; set; }
        public required string Genre { get; set; }
        public int? Rating { get; set; }

        public ICollection<Author> Author { get; set; } = new List<Author>();

        //public ICollection<BookCheckout> BookCheckouts { get; set; } = new List<BookCheckout>();
    }
}
