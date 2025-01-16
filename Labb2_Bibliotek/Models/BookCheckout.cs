namespace Labb2_Bibliotek.Classes
{
    public class BookCheckout
    {
        public int Id {  get; set; }
        public DateTime CheckedOutDate {  get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; } = false;
        public required Book Book { get; set; }
        public required Member Member { get; set; }
    }
}
