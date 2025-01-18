using Labb2_Bibliotek.Classes;
using System.ComponentModel.DataAnnotations;

namespace Labb2_Bibliotek.DTOs
{
    public class MemberDTO
    {
        public int MemberId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public DateOnly RegisteredMembership { get; set; }

        public ICollection<BookCheckout> BookCheckouts { get; set; } = new List<BookCheckout>();
    }
}
