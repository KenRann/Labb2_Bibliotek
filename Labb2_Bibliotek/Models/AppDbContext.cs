using Labb2_Bibliotek.Classes;
using Microsoft.EntityFrameworkCore;

namespace Labb2_Bibliotek.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {          
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<BookCheckout> BookCheckouts { get; set; }
        public DbSet<Labb2_Bibliotek.Classes.Author> Author { get; set; } = default!;
    }
}
