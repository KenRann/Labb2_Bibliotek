namespace Labb2_Bibliotek.Classes
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public bool IsCheckedOut { get; set; }
        public int ReleaseYear { get; set; }

        public int Rating { get; set; }

        public List<BookStatus> Status { get; set; }
    }
}
