using Labb2_Bibliotek.Classes;
using Labb2_Bibliotek.DTOs;
using System.Text.Json.Serialization;

namespace Labb2_Bibliotek.DTO
{
    public class CreateBookDTO
    {
        public required string Title { get; set; }
        public string? Isbn { get; set; }
        public required int ReleaseYear { get; set; }
        public required string Genre { get; set; }
        
        public ICollection<AuthorDTO> Author { get; set; } = new List<AuthorDTO>();
    }
}
