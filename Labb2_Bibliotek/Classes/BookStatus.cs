namespace Labb2_Bibliotek.Classes
{
    public class BookStatus
    {
        public int BSId {  get; set; }

        public DateTime CheckedOutDate {  get; set; }
        public DateTime ReturnDate { get; set; }

        public Book Book { get; set; }
        public LibraryMember LibraryMember { get; set; }
    }
}
