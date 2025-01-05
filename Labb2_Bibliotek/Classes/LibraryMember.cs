namespace Labb2_Bibliotek.Classes
{
    public class LibraryMember
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public List<BookStatus> Status { get; set; }
    }
}
