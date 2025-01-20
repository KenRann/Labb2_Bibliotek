using Labb2_Bibliotek.Classes;

namespace Labb2_Bibliotek.DTOs
{
    public class BookCheckoutDTO
    {
        public int BookCheckoutId { get; set; }
        public DateTime CheckedOutDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; } = true;
        public required Book Book { get; set; }
        public required Member Member { get; set; }
    }
}
