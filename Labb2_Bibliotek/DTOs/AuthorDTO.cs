using Labb2_Bibliotek.Classes;

namespace Labb2_Bibliotek.DTOs
{
    public class AuthorDTO
    {
        public required string Name { get; set; }

        public ICollection<BookDTO>? Books { get; set; } = new List<BookDTO>();
    }
}
