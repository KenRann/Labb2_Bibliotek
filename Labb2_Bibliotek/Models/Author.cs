using System.Text.Json.Serialization;

namespace Labb2_Bibliotek.Classes
{
    public class Author
    {
        public int AuthorId { get; set; }
        public required string Name { get; set; }      
        public ICollection<Book>? Books { get; set; } = new List<Book>();
    }
}
