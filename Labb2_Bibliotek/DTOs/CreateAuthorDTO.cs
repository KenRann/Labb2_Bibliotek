using Labb2_Bibliotek.Classes;

namespace Labb2_Bibliotek.DTOs
{
    public class CreateAuthorDTO
    {
        public required string Name { get; set; }
        public ICollection<Book>? Books { get; set; } = new List<Book>();
    }
}
