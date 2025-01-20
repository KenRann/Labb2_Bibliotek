using Labb2_Bibliotek.Classes;

namespace Labb2_Bibliotek.DTOs
{
    public class BookCheckoutDTO
    {
        public int Id { get; set; }
        public DateTime CheckedOutDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; } = false;
        public required Book Book { get; set; }
        public required Member Member { get; set; }
    }
}
