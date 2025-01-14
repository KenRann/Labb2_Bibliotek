namespace Labb2_Bibliotek.Classes
{
    public class BookCheckout
    {
        public int Id {  get; set; }
        public DateTime CheckedOutDate {  get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; }
        public Book Book { get; set; }
        public Member Member { get; set; }
    }
}
