namespace Labb2_Bibliotek.Classes
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string? Isbn { get; set; }
        public bool IsCheckedOut { get; set; }
        public int ReleaseYear { get; set; }
        public int Rating { get; set; }

        public ICollection<Author> Author { get; set; } = new List<Author>();
        public ICollection<BookCheckout> BookCheckouts { get; set; } = new List<BookCheckout>();
    }
}
