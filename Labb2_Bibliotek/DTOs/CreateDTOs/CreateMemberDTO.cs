using System.ComponentModel.DataAnnotations;

namespace Labb2_Bibliotek.DTOs.CreateDTOs
{
    public class CreateMemberDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public DateOnly RegisteredMembership { get; set; }
    }
}
