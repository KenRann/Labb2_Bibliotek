namespace Labb2_Bibliotek.Classes
{
    public class Member
    {
        public int MemberId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public DateTime RegisteredMembership {  get; set; }

        //public ICollection<BookCheckout> BookCheckouts { get; set; } = new List<BookCheckout>();
    }
}
