using System.ComponentModel.DataAnnotations;

namespace Labb2_Bibliotek.DTOs
{
    public class CreateMemberDTO
    {
        
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public DateTime RegisteredMembership { get; set; }
    }
}
