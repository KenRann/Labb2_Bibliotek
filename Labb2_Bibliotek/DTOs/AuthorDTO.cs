using Labb2_Bibliotek.Classes;

namespace Labb2_Bibliotek.DTOs
{
    public class AuthorDTO
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public ICollection<BookDTO>? Books { get; set; } = new List<BookDTO>();
    }
}
